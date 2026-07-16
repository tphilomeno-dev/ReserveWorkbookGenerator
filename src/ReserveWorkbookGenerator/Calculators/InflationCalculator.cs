using ReserveWorkbookGenerator.Common;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Calculators;

/// <summary>
/// Applies annual inflation to reserve component replacement costs.
/// </summary>
public class InflationCalculator
{
    /// <summary>
    /// Applies one year of inflation.
    /// </summary>
    public void Execute(
        IEnumerable<ReserveComponent> components,
        decimal inflationRate)
    {
        foreach (var component in components)
        {
            component.ReplacementCost =
                Money.Round(
                    component.ReplacementCost *
                    (1 + inflationRate));
        }
    }
}