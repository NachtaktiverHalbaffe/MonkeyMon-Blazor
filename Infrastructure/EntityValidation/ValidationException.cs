namespace MonkeyMon_Blazor.Infrastructure.EntityValidation;

[Serializable]
#pragma warning disable S3925 // "ISerializable" should be implemented correctly
public class ValidationException : Exception
#pragma warning restore S3925 // "ISerializable" should be implemented correctly
{
    public ValidationException()
    {
        this.ValidationResults = [];
    }

    public ValidationException(IEnumerable<EntityValidationResult> validationResults)
    {
        this.ValidationResults = validationResults;
    }

    public IEnumerable<EntityValidationResult> ValidationResults { get; }
}
