using ReserveWorkbookGenerator.Common;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Financial;

/// <summary>
/// Calculates reserve expenditures for a projection year.
/// </summary>
public class ReserveExpenditureCalculator
{
    /// <summary>
    /// Calculates the total reserve expenditures for the year.
    /// </summary>
    public decimal Calculate(
        IEnumerable<ReserveComponent> components)
    {
        return Money.Round(
            components
                .Where(c => c.RemainingLife == 0)
                .Sum(c => c.ReplacementCost));
    }
}