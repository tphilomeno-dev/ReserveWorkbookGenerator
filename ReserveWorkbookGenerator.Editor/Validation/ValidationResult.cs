namespace ReserveWorkbookGenerator.Editor.Validation;

public sealed class ValidationResult
{
    public ValidationSeverity Severity { get; set; }

    public string Message { get; set; } = string.Empty;
}