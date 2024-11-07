using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonkeyMon_Blazor.Infrastructure.EntityValidation;
using MonkeyMon_Blazor.Models;
using ValidationException = MonkeyMon_Blazor.Infrastructure.EntityValidation.ValidationException;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace MonkeyMon_Blazor.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Monkey> Monkeys { get; set; } = null!;

    public DbSet<Species> Species { get; set; } = null!;

    public DbSet<Pokemon> PokedexEntries { get; set; } = null!;

    public DbSet<MonMoves> MonMoves { get; set; } = null!;

    public DbSet<MonType> MonTypes { get; set; } = null!;

    public DbSet<PokemonSpriteResponse> PokemonSprites { get; set; } = null!;
    public override int SaveChanges()
    {
        ValidateEntities();

        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        ValidateEntities();

        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ValidateEntities();

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        builder.Entity<Species>(options =>
        {
            var dictValueConverter = new ValueConverter<IDictionary<string, string>, string>(
                m => JsonSerializer.Serialize(m, JsonSerializerOptions.Default),
                s => string.IsNullOrWhiteSpace(s)
                    ? new Dictionary<string, string>()
                    : JsonSerializer.Deserialize<IDictionary<string, string>>(s, JsonSerializerOptions.Default) ??
                      new Dictionary<string, string>()
            );

            var stringArrayValueConverter = new ValueConverter<ICollection<string>, string>(
                l => string.Join(",", l),
                s => string.IsNullOrWhiteSpace(s)
                    ? new Collection<string>()
                    : new Collection<string>(s.Split(new[] { ',' }).ToArray())
            );

            options
                .Property(s => s.Characteristics)
                .HasConversion(dictValueConverter);
            options.Property(s => s.Taxonomy)
                .HasConversion(dictValueConverter);
            options.Property(s => s.Locations).HasConversion(stringArrayValueConverter);
            ;
        });

        // Seed data conditionally
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            GenerateSeedData(builder);
        }
    }

    private static void GenerateSeedData(ModelBuilder builder)
    {
        var monkeys = new Faker<Monkey>()
            .RuleFor(m => m.Name, f => f.Name.FirstName())
            .RuleFor(m => m.KnownFrom, f => f.Commerce.ProductName())
            .RuleFor(m => m.Attack, f => f.Random.UShort(0, 723))
            .RuleFor(m => m.Defense, f => f.Random.UShort(0, 654))
            .RuleFor(m => m.SpecialAttack, f => f.Random.UShort(0, 624))
            .RuleFor(m => m.SpecialDefense, f => f.Random.UShort(0, 654))
            .RuleFor(m => m.Speed, f => f.Random.UShort(0, 854))
            .RuleFor(m => m.HealthPoints, f => f.Random.UShort(0, 714))
            .GenerateBetween(70, 100);
        builder.Entity<Monkey>().HasData(monkeys);
    }

    private void ValidateEntities()
    {
        var addedOrModifiedEntities = ChangeTracker.Entries()
            .Where(e => e.State is EntityState.Added or EntityState.Modified);

        var errors = new List<EntityValidationResult>();
        var validationResults = new List<ValidationResult>();
        foreach (var entity in addedOrModifiedEntities.Select(x => x.Entity))
        {
            if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults))
            {
                validationResults.ForEach(e => Console.WriteLine(e.ErrorMessage?.ToString()));
                errors.Add(new EntityValidationResult(entity, validationResults));
                validationResults = [];
            }
        }

        if (errors.Count > 0)
        {
            throw new ValidationException(errors);
        }
    }
}