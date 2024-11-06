using System.ComponentModel.DataAnnotations;
using Bogus;
using Microsoft.EntityFrameworkCore;
using MonkeyMon_Blazor.Infrastructure.EntityValidation;
using MonkeyMon_Blazor.Models;
using ValidationException = MonkeyMon_Blazor.Infrastructure.EntityValidation.ValidationException;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace MonkeyMon_Blazor.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Monkey> Monkeys { get; set; } = null!;

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