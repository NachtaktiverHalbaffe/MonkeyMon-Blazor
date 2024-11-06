using System.ComponentModel.DataAnnotations;

namespace MonkeyMon_Blazor.Infrastructure.EntityValidation
{
    public class EntityValidationResult(object entity, List<ValidationResult> validationResults)
    {
        public object Entity { get; set; } = entity;

        public ICollection<ValidationResult> ValidationErrors { get; } = validationResults;
    }
}
