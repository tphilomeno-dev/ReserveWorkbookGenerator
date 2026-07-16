using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Calculators;

/// <summary>
/// Renews reserve components after replacement.
/// </summary>
public class ComponentRenewalCalculator
{
    /// <summary>
    /// Renews all components that have reached the end of their useful life.
    /// </summary>
    public void Execute(
        IEnumerable<ReserveComponent> components,
        int replacementYear)
    {
        foreach (var component in components.Where(c => c.RemainingLife == 0))
        {
            component.LastReplaced = replacementYear;
            component.RemainingLife = component.UsefulLife;
        }
    }
}