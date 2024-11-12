using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using MonkeyMon_Blazor.Infrastructure;
using MonkeyMon_Blazor.Models;

namespace MonkeyMon_Blazor.Services;

public class FetchPokeApiStartupTask : IHostedService
{
    private PokeApiService pokeApiService = null!;
    private ApplicationDbContext dbContext = null!;
    private readonly IServiceScopeFactory serviceScopeFactory;

    public FetchPokeApiStartupTask(IServiceScopeFactory serviceScopeFactory)
    {
        this.serviceScopeFactory = serviceScopeFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceScopeFactory.CreateScope();
        pokeApiService = scope.ServiceProvider.GetRequiredService<PokeApiService>();
        dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var nrExistingPokemon = await dbContext.Pokemons.CountAsync(cancellationToken: cancellationToken);

        var fetchAblePokemon =
            await pokeApiService.GetNamedResourcePageAsync<PokemonResponse>(20, 0, cancellationToken);

        if (nrExistingPokemon != fetchAblePokemon.Results.Count)
        {
            foreach (var pokemonName in fetchAblePokemon.Results)
            {
                var pokemonResponse =
                    await pokeApiService.GetResourceAsync<PokemonResponse>(pokemonName, cancellationToken);

                if (await dbContext.Pokemons.AnyAsync(pokemon => pokemon.Id == pokemonResponse.Id,
                        cancellationToken: cancellationToken))
                {
                    continue;
                }

                var pokemon = new Pokemon
                {
                    Name = pokemonResponse.Name,
                    Id = pokemonResponse.Id,
                    Weight = pokemonResponse.Weight,
                    Types = [],
                    Moves = []
                };

                var monTypes = await GenerateMonTypes(pokemonResponse.Types, cancellationToken);
                foreach (var monType in monTypes)
                {
                    pokemon.Types.Add(monType);
                }

                GeneratePokemonStats(pokemonResponse.Stats, pokemon);

                var pokemonSprites = GeneratePokemonSprite(pokemonResponse.SpritesResponse);
                pokemonSprites.PokemonId = pokemon.Id;
                await dbContext.PokemonSprites.AddAsync(pokemonSprites, cancellationToken);

                var pokemonMoves = await GenerateMonMoves(pokemonResponse.Moves, cancellationToken);
                foreach (var pokemonMove in pokemonMoves)
                {
                    pokemon.Moves.Add(pokemonMove);
                }

                await dbContext.Pokemons.AddAsync(pokemon, cancellationToken);
            }

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    private async Task<Collection<MonType>> GenerateMonTypes(List<PokemonTypeResponse> pokemonTypeResponse,
        CancellationToken cancellationToken)
    {
        var types = new Collection<MonType>();
        foreach (var pokemonResponseType in pokemonTypeResponse)
        {
            var pokemonType = await _GenerateMonType(pokemonResponseType.Type.Name, cancellationToken);
            types.Add(pokemonType);
        }

        return types;
    }

    private async Task<MonType> _GenerateMonType(string resourceName, CancellationToken cancellationToken)
    {
        var existingType = await dbContext.MonTypes
            .SingleOrDefaultAsync(type => type.Name.ToLower().Contains(resourceName.ToLower()),
                cancellationToken: cancellationToken);

        if (existingType is null)
        {
            var type = await pokeApiService.GetResourceAsync<TypeResponse>(resourceName,
                cancellationToken);

            var monType = new MonType
            {
                Name = type.Name,
            };

            var pokemonRelationType =
                await _GenerateMonTypeRelation(type.DamageRelationsResponse, cancellationToken);
            pokemonRelationType.MonTypeId = monType.Id;

            monType.MonTypeRelation = pokemonRelationType;
            await dbContext.AddAsync(pokemonRelationType, cancellationToken);
            await dbContext.MonTypes.AddAsync(monType, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return monType;
        }
        else
        {
            return existingType;
        }
    }


    private async Task<MonTypeRelation> _GenerateMonTypeRelation(TypeRelationsResponse typeRelationDto,
        CancellationToken cancellationToken)
    {
        var typeResponse = new MonTypeRelation();

        var doubleDamageTo = await _FetchAllTypes(typeRelationDto.DoubleDamageTo, cancellationToken);
        typeResponse.DoubleDamageTo = doubleDamageTo;

        var doubleDamageFrom = await _FetchAllTypes(typeRelationDto.DoubleDamageFrom, cancellationToken);
        typeResponse.DoubleDamageFrom = doubleDamageFrom;

        var halfDamageTo = await _FetchAllTypes(typeRelationDto.HalfDamageTo, cancellationToken);
        typeResponse.HalfDamageTo = halfDamageTo;

        var halfDamageFrom = await _FetchAllTypes(typeRelationDto.HalfDamageFrom, cancellationToken);
        typeResponse.HalfDamageFrom = halfDamageFrom;

        var noDamageTo = await _FetchAllTypes(typeRelationDto.NoDamageTo, cancellationToken);
        typeResponse.NoDamageTo = noDamageTo;

        var noDamageFrom = await _FetchAllTypes(typeRelationDto.NoDamageFrom, cancellationToken);
        typeResponse.NoDamageFrom = noDamageFrom;

        return typeResponse;
    }

    private async Task<ICollection<MonType>> _FetchAllTypes(List<PokeApiNamedApiResource<TypeResponse>> types,
        CancellationToken cancellationToken)
    {
        var monTypes = new Collection<MonType>();
        foreach (var type in types)
        {
            var existingType = await dbContext.MonTypes.SingleOrDefaultAsync(t => t.Name.ToLower().Contains(type.Name.ToLower()), cancellationToken);

            if (existingType is not null)
            {
                monTypes.Add(existingType);
            }
        }

        return monTypes;
    }

    private void GeneratePokemonStats(List<PokemonStatResponse> statResponse, Pokemon pokemon)
    {
        foreach (var pokemonResponseStat in statResponse)
        {
            switch (pokemonResponseStat.Stat.Name.ToLower())
            {
                case "hp":
                    pokemon.HealthPoints = (ushort)pokemonResponseStat.BaseStat;
                    break;
                case "attack":
                    pokemon.Attack = (ushort)pokemonResponseStat.BaseStat;
                    break;
                case "defense":
                    pokemon.Defense = (ushort)pokemonResponseStat.BaseStat;
                    break;
                case "special-attack":
                    pokemon.SpecialAttack = (ushort)pokemonResponseStat.BaseStat;
                    break;
                case "special-defense":
                    pokemon.SpecialDefense = (ushort)pokemonResponseStat.BaseStat;
                    break;
                case "speed":
                    pokemon.Speed = (ushort)pokemonResponseStat.BaseStat;
                    break;
            }
        }
    }

    private PokemonSprite GeneratePokemonSprite(PokemonSpritesResponse spritesResponse)
    {
        return new PokemonSprite
        {
            FrontDefault = spritesResponse.FrontDefault,
            FrontShiny = spritesResponse.FrontShiny,
            FrontFemale = spritesResponse.FrontFemale,
            FrontShinyFemale = spritesResponse.FrontShinyFemale,
            BackDefault = spritesResponse.BackDefault,
            BackShiny = spritesResponse.BackShiny,
            BackShinyFemale = spritesResponse.BackShinyFemale
        };
    }

    private async Task<ICollection<MonMove>> GenerateMonMoves(List<MoveResponse> movesResponse,
        CancellationToken cancellationToken)
    {
        var moves = new Collection<MonMove>();

        foreach (var moveResponse in movesResponse.ToList())
        {
            if (moveResponse.Id == 0)
            {
                continue;
            }

            var existingMove =
                await dbContext.MonMoves.SingleOrDefaultAsync(move => move.Id == moveResponse.Id, cancellationToken);
            if (existingMove is null)
            {
                var newMove = new MonMove
                {
                    Id = moveResponse.Id,
                    Name = moveResponse.Name,
                    Accuracy = moveResponse.Accuracy,
                    EffectChance = moveResponse.EffectChance,
                    Pp = moveResponse.Pp,
                    Priority = moveResponse.Priority,
                    Power = moveResponse.Power,
                    DamageClass = moveResponse.DamageClass.Name,
                    Description = moveResponse.FlavorTextEntries.First(entry => entry.Language.Name == "de").FlavorText
                };

                var typList = await _GenerateMonType(
                    moveResponse.Type.Name,
                    cancellationToken);
                newMove.TypeId = typList.Id;

                moves.Add(newMove);
            }
            else
            {
                moves.Add(existingMove);
            }
        }

        return moves;
    }
}