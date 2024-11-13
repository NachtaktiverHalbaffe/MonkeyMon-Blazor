using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using MonkeyMon_Blazor.Infrastructure;
using MonkeyMon_Blazor.Models;

namespace MonkeyMon_Blazor.Services;

public class FetchPokeApiStartupTask(IServiceScopeFactory serviceScopeFactory) : IHostedService
{
    private PokeApiService pokeApiService = null!;
    private ApplicationDbContext dbContext = null!;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceScopeFactory.CreateScope();
        pokeApiService = scope.ServiceProvider.GetRequiredService<PokeApiService>();
        dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var nrExistingPokemon = await dbContext.Pokemons.CountAsync(cancellationToken: cancellationToken);

        var fetchAblePokemon =
            await pokeApiService.GetNamedResourcePageAsync<PokemonResponse>(10, 0, cancellationToken);

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
                    Weight = Math.Round(pokemonResponse.Weight * 0.1, 2),
                    Height = Math.Round(pokemonResponse.Height * 0.1, 2),
                    Types = [],
                    Moves = []
                };

                var monTypes = await GenerateMonTypes(pokemonResponse.Types, cancellationToken);
                foreach (var monType in monTypes)
                {
                    pokemon.Types.Add(monType);
                }

                var pokemonMoves = await GenerateMonMoves(pokemonResponse.Moves, cancellationToken);
                foreach (var pokemonMove in pokemonMoves)
                {
                    pokemon.Moves.Add(pokemonMove);
                }

                (pokemon.Name, pokemon.Description, pokemon.Species, pokemon.IsMale, pokemon.IsFemale) =
                    await GenerateNameAndDescription(pokemonResponse.Species);

                GeneratePokemonStats(pokemonResponse.Stats, pokemon);

                var pokemonSprites = GeneratePokemonSprite(pokemonResponse.SpritesResponse);
                pokemonSprites.PokemonId = pokemon.Id;
                await dbContext.PokemonSprites.AddAsync(pokemonSprites, cancellationToken);
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
            .AsSplitQuery()
            .Include(t => t.DoubleDamageFrom)
            .Include(t => t.DoubleDamageTo)
            .Include(t => t.HalfDamageFrom)
            .Include(t => t.HalfDamageTo)
            .Include(t => t.NoDamageFrom)
            .Include(t => t.NoDamageTo)
            .SingleOrDefaultAsync(type => type.Name == resourceName,
                cancellationToken: cancellationToken);
        
        var type = await pokeApiService.GetResourceAsync<TypeResponse>(resourceName,
            cancellationToken);

        if (existingType is null)
        {
            var monType = new MonType
            {
                Id = type.Id,
                Name = type.Name,
            };
            await _GenerateMonTypeRelation(type.DamageRelationsResponse, monType, cancellationToken);

            await dbContext.MonTypes.AddAsync(monType, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return monType;
        }
        else
        {
            await _GenerateMonTypeRelation(type.DamageRelationsResponse, existingType, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return existingType;
        }
    }


    private async Task _GenerateMonTypeRelation(TypeRelationsResponse typeRelationDto, MonType forType,
        CancellationToken cancellationToken)
    {
        var doubleDamageTo = await _FetchAllTypes(typeRelationDto.DoubleDamageTo, cancellationToken);
        foreach (var monType in doubleDamageTo)
        {
            var alreadyExists = forType.DoubleDamageTo.Any(type => type.Id == monType.Id);

            if (!alreadyExists)
            {
                forType.DoubleDamageTo.Add(monType);
            }
        }

        var doubleDamageFrom = await _FetchAllTypes(typeRelationDto.DoubleDamageFrom, cancellationToken);
        foreach (var monType in doubleDamageFrom)
        {
            var alreadyExists = forType.DoubleDamageFrom.Any(type => type.Id == monType.Id);

            if (!alreadyExists)
            {
                forType.DoubleDamageFrom.Add(monType);
            }
        }

        var halfDamageTo = await _FetchAllTypes(typeRelationDto.HalfDamageTo, cancellationToken);
        foreach (var monType in halfDamageTo)
        {
            var alreadyExists = forType.HalfDamageTo.Any(type => type.Id == monType.Id);

            if (!alreadyExists)
            {
                forType.HalfDamageTo.Add(monType);
            }
        }

        var halfDamageFrom = await _FetchAllTypes(typeRelationDto.HalfDamageFrom, cancellationToken);
        foreach (var monType in halfDamageFrom)
        {
            var alreadyExists = forType.HalfDamageFrom.Any(type => type.Id == monType.Id);

            if (!alreadyExists)
            {
                forType.HalfDamageFrom.Add(monType);
            }
        }

        var noDamageTo = await _FetchAllTypes(typeRelationDto.NoDamageTo, cancellationToken);
        foreach (var monType in noDamageTo)
        {
            var alreadyExists = forType.NoDamageTo.Any(type => type.Id == monType.Id);

            if (!alreadyExists)
            {
                forType.NoDamageTo.Add(monType);
            }
        }

        var noDamageFrom = await _FetchAllTypes(typeRelationDto.NoDamageFrom, cancellationToken);
        foreach (var monType in noDamageFrom)
        {
            var alreadyExists = forType.NoDamageFrom.Any(type => type.Id == monType.Id);

            if (!alreadyExists)
            {
                forType.NoDamageFrom.Add(monType);
            }
        }
    }

    private async Task<ICollection<MonType>> _FetchAllTypes(List<PokeApiNamedApiResource<TypeResponse>> types,
        CancellationToken cancellationToken)
    {
        var monTypes = new Collection<MonType>();
        foreach (var type in types)
        {
            var existingType =
                await dbContext.MonTypes
                    .SingleOrDefaultAsync(t => t.Name == type.Name,
                        cancellationToken);

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

    private async Task<ICollection<MonMove>> GenerateMonMoves(List<PokemonMoveResponse> movesResponse,
        CancellationToken cancellationToken)
    {
        var moves = new Collection<MonMove>();

        foreach (var moveResponse in movesResponse.ToList())
        {
            var existingMove =
                await dbContext.MonMoves.SingleOrDefaultAsync(
                    move => move.Name.ToLower() == moveResponse.Move.Name.ToLower(), cancellationToken);
            if (existingMove is null)
            {
                var fetchedMove =
                    await pokeApiService.GetResourceAsync<MoveResponse>(moveResponse.Move.Name, cancellationToken);
                var newMove = new MonMove
                {
                    Id = fetchedMove.Id,
                    Name = fetchedMove.Name,
                    Accuracy = fetchedMove.Accuracy,
                    EffectChance = fetchedMove.EffectChance,
                    Pp = fetchedMove.Pp,
                    Priority = fetchedMove.Priority,
                    Power = fetchedMove.Power,
                    DamageClass = fetchedMove.DamageClass.Name,
                    Description =
                        fetchedMove.FlavorTextEntries.FirstOrDefault(entry => entry.Language.Name == "de")
                            ?.FlavorText ?? string.Empty
                };

                var type = await _GenerateMonType(
                    fetchedMove.Type.Name,
                    cancellationToken);
                newMove.Type = type;

                await dbContext.MonMoves.AddAsync(newMove, cancellationToken);
                await dbContext.SaveChangesAsync(cancellationToken);
                moves.Add(newMove);
            }
            else
            {
                moves.Add(existingMove);
            }
        }

        return moves;
    }

    private async Task<(string name, string description, string species, bool isMale, bool isFemale)>
        GenerateNameAndDescription(
            PokeApiNamedApiResource<PokemonSpeciesResponse> species)
    {
        var fetchedSpecies = await pokeApiService.GetResourceAsync<PokemonSpeciesResponse>(species.Name);

        var name = fetchedSpecies.Names
            .FirstOrDefault(entry => entry.Language.Name.Contains("de", StringComparison.CurrentCultureIgnoreCase))
            ?.Name ?? "";

        var description = fetchedSpecies.FlavorTextEntries
            .FirstOrDefault(entry => entry.Language.Name.Contains("de", StringComparison.CurrentCultureIgnoreCase))
            ?.FlavorText ?? "";

        var speciesLocalizedResponse = fetchedSpecies.Genera
            .FirstOrDefault(entry => entry.Language.Name.Contains("de", StringComparison.CurrentCultureIgnoreCase))
            ?.Genus ?? "";

        var isMale = fetchedSpecies.GenderRate switch
        {
            -1 => false,
            8 => false,
            _ => true
        };

        var isFemale = fetchedSpecies.GenderRate switch
        {
            -1 => false,
            0 => false,
            _ => true
        };

        return (name, description, speciesLocalizedResponse, isMale, isFemale);
    }
}