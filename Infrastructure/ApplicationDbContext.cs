using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using MonkeyMon_Blazor.Infrastructure.EntityValidation;
using MonkeyMon_Blazor.Models;

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
            throw new ValidationException(errors.ToString());
        }
    }
}