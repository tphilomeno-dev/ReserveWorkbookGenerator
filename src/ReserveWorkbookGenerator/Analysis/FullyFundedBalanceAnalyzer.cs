using ReserveWorkbookGenerator.Common;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Analysis;

/// <summary>
/// Calculates the portfolio Fully Funded Balance.
/// </summary>
public class FullyFundedBalanceAnalyzer
{
    public decimal Calculate(
        IEnumerable<ReserveScheduleRow> schedule)
    {
        return Money.Round(
            schedule.Sum(r => r.FFB));
    }
}