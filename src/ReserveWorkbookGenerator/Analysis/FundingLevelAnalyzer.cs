using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Analysis;

/// <summary>
/// Classifies reserve funding strength based on Percent Funded.
/// </summary>
public class FundingLevelAnalyzer
{
    public FundingLevel Calculate(
        decimal percentFunded)
    {
        if (percentFunded < 0.30m)
            return FundingLevel.Weak;

        if (percentFunded < 0.70m)
            return FundingLevel.Fair;

        return FundingLevel.Strong;
    }
}