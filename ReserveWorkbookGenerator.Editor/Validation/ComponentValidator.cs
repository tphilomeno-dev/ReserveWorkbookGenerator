using ReserveWorkbookGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveWorkbookGenerator.Editor.Validation
{
    public class ComponentValidator
    {
        public static void ValidateComponent(
            ReserveComponent component,
            List<ValidationResult> results)
        {
            if (string.IsNullOrWhiteSpace(component.Name))
            {
                results.Add(new ValidationResult
                {
                    Severity = ValidationSeverity.Error,
                    Message = "A reserve component is missing its description."
                });
            }
            if (component.ReplacementCost <= 0)
            {
                results.Add(new ValidationResult
                {
                    Severity = ValidationSeverity.Error,
                    Message =
                        $"'{component.Name}' has an invalid replacement cost."
                });
            }
            if (component.UsefulLife <= 0)
            {
                results.Add(new ValidationResult
                {
                    Severity = ValidationSeverity.Error,
                    Message =
                        $"'{component.Name}' has an invalid useful life."
                });
            }
            if (component.RemainingLife < 0)
            {
                results.Add(new ValidationResult
                {
                    Severity = ValidationSeverity.Error,
                    Message =
                        $"'{component.Name}' has a negative remaining life."
                });
            }
            if (component.RemainingLife > component.UsefulLife)
            {
                results.Add(new ValidationResult
                {
                    Severity = ValidationSeverity.Error,
                    Message =
                        $"'{component.Name}' has a remaining life greater than its useful life."
                });
            }
        }
    }
}
