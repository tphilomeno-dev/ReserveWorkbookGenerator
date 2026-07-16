using ReserveWorkbookGenerator.Analysis;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Engine;

/// <summary>
/// Performs funding analysis for reserve projections.
/// </summary>
public class FundingAnalysisEngine
{
    private readonly FullyFundedBalanceAnalyzer _ffbAnalyzer = new();
    private readonly PercentFundedAnalyzer _percentAnalyzer = new();
    private readonly FundingLevelAnalyzer _levelAnalyzer = new();
    private readonly FundingTrendAnalyzer _trendAnalyzer = new();

    public void Analyze(
        ReserveProjection projection)
    {
        if (projection == null)
            throw new ArgumentNullException(nameof(projection));

        decimal previousPercent = 0m;

        foreach (var year in projection.Years)
        {
            year.FullyFundedBalance =
                _ffbAnalyzer.Calculate(year.Schedule);

            year.PercentFunded =
                _percentAnalyzer.Calculate(
                    year.EndingPool,
                    year.FullyFundedBalance);

            year.FundingLevel =
                _levelAnalyzer.Calculate(
                    year.PercentFunded);

            year.FundingTrend =
                _trendAnalyzer.Calculate(
                    year.PercentFunded,
                    previousPercent);

            previousPercent = year.PercentFunded;
        }
    }
}