using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Analysis;

/// <summary>
/// Determines whether reserve funding is improving,
/// stable or declining.
/// </summary>
public class FundingTrendAnalyzer
{
    public FundingTrend Calculate(
        decimal currentPercentFunded,
        decimal previousPercentFunded)
    {
        if (currentPercentFunded > previousPercentFunded)
            return FundingTrend.Improving;

        if (currentPercentFunded < previousPercentFunded)
            return FundingTrend.Declining;

        return FundingTrend.Stable;
    }
}