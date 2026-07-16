namespace ReserveWorkbookGenerator.Models;

/// <summary>
/// Summary information for a scenario comparison.
/// </summary>
public sealed class ScenarioComparisonRow
{
    public string ScenarioName { get; set; } = string.Empty;

    public decimal EndingPool { get; set; }

    public decimal FullyFundedBalance { get; set; }

    public decimal PercentFunded { get; set; }

    public FundingLevel FundingLevel { get; set; }
}