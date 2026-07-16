using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Analysis;

/// <summary>
/// Determines whether an investment matures during
/// a projection year.
/// </summary>
public class InvestmentMaturityAnalyzer
{
    public bool MaturesInYear(
        InvestmentAccount account,
        int year)
    {
        ArgumentNullException.ThrowIfNull(account);

        return account.MaturityDate?.Year == year;
    }
}