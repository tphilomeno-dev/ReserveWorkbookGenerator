using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Editor.Validation;

public sealed class StudyValidator
{
    public List<ValidationResult> Validate(ReserveStudy study)
    {
        var results = new List<ValidationResult>();

        // Association Name

        if (string.IsNullOrWhiteSpace(study.Study.AssociationName))
        {
            results.Add(new ValidationResult
            {
                Severity = ValidationSeverity.Error,
                Message = "Association Name is required."
            });
        }

        // Study Year

        if (study.Settings.StudyYear < 2000)
        {
            results.Add(new ValidationResult
            {
                Severity = ValidationSeverity.Error,
                Message = "Study Year must be 2000 or greater."
            });
        }

        // Unit Count

        if (study.Settings.UnitCount <= 0)
        {
            results.Add(new ValidationResult
            {
                Severity = ValidationSeverity.Error,
                Message = "Unit Count must be greater than zero."
            });
        }

        foreach (var component in study.Components)
        {
           ComponentValidator.ValidateComponent(component, results);
        }
        return results;
    }
    
}