namespace ReserveWorkbookGenerator.Models;

public class ReserveProjectionYear
{
    public int Year { get; set; }

    public decimal BeginningPool { get; set; }

    public decimal AnnualContributions { get; set; }

    public decimal InterestEarned { get; set; }

    public decimal ReserveExpenditures { get; set; }

    /// <summary>
    /// Reserve schedule for this projected year.
    /// This is a snapshot of the reserve study for the year.
    /// </summary>
    public List<ReserveScheduleRow> Schedule { get; set; } = new();
    public decimal EndingPool { get; set; }

    public decimal FullyFundedBalance { get; set; }

    public decimal PercentFunded { get; set; }

    public FundingLevel FundingLevel { get; set; }

    public FundingTrend FundingTrend { get; set; }
}