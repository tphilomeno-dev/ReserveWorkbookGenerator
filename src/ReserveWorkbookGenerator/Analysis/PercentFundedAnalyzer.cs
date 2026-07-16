using ReserveWorkbookGenerator.Common;

namespace ReserveWorkbookGenerator.Analysis;

/// <summary>
/// Calculates the Percent Funded ratio.
/// </summary>
public class PercentFundedAnalyzer
{
    public decimal Calculate(
        decimal reservePool,
        decimal fullyFundedBalance)
    {
        if (fullyFundedBalance == 0m)
            return 0m;

        return Money.Round(
            reservePool / fullyFundedBalance);
    }
}