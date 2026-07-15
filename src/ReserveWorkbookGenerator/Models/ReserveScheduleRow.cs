using ReserveWorkbookGenerator.Extensions;

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
    /// <summary>
    /// Creates a deep copy of the reserve schedule row.
    /// </summary>
    public ReserveScheduleRow Clone()
    {
        return new ReserveScheduleRow
        {
            Component = Component.Clone(),

            FFB = FFB,
            FfbWeight = FfbWeight,
            BeginningAllocation = BeginningAllocation,
            RemainingRequired = RemainingRequired,
            ReplacementCostWeight = ReplacementCostWeight,
            AnnualContribution = AnnualContribution,
            InterestAllocation = InterestAllocation,
            ReserveExpenditure = ReserveExpenditure,
            EndingAllocation = EndingAllocation,
            FundRatio = FundRatio,
            MonthlyContribution = MonthlyContribution,
            MonthlyCpu = MonthlyCpu
        };
    }
}