using ReserveWorkbookGenerator.Common;

namespace ReserveWorkbookGenerator.Financial;

/// <summary>
/// Calculates annual interest using a fixed annual interest rate.
/// </summary>
public class FixedRateInterestCalculator
{
    /// <summary>
    /// Calculates the annual interest earned.
    /// </summary>
    public decimal Calculate(
        decimal beginningPool,
        decimal annualInterestRate)
    {
        return Money.Round(
            beginningPool * annualInterestRate);
    }
}