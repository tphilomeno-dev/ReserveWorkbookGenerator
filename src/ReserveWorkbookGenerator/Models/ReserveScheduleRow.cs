namespace ReserveWorkbookGenerator.Models;

public sealed class ReserveScheduleRow
{
    public ReserveComponent Component { get; init; } = null!;

    public decimal FFB { get; set; }

    public decimal FfbWeight { get; set; }

    public decimal BeginningAllocation { get; set; }

    public decimal RemainingRequired { get; set; }

    public decimal ReplacementCostWeight { get; set; }

    public decimal AnnualContribution { get; set; }

    public decimal InterestAllocation { get; set; }

    public decimal ReserveExpenditure { get; set; }

    public decimal EndingAllocation { get; set; }

    public decimal FundRatio { get; set; }

    public decimal MonthlyContribution { get; set; }

    public decimal MonthlyCpu { get; set; }
}