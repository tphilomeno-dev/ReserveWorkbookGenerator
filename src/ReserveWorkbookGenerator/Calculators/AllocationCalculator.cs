using ReserveWorkbookGenerator.Common;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Calculators;

public class AllocationCalculator
{
    public void Execute(
    IList<ReserveScheduleRow> rows,
    ReserveSettings settings)
    {
        if (rows == null)
            throw new ArgumentNullException(nameof(rows));

        if (!rows.Any())
            return;

        decimal totalFfb =
            rows.Sum(r => r.FFB);

        decimal totalReplacementCost =
            rows.Sum(r => r.Name.ReplacementCost);

        foreach (var row in rows)
        {
            decimal weight;

            switch (settings.AllocationMethod)
            {
                case AllocationMethod.FullyFundedBalance:

                    weight =
                        totalFfb == 0
                            ? 0
                            : row.FFB / totalFfb;

                    break;

                case AllocationMethod.PercentOfReplacementCost:

                    weight =
                        totalReplacementCost == 0
                            ? 0
                            : row.Name.ReplacementCost / totalReplacementCost;

                    break;

                case AllocationMethod.Manual:

                    continue;

                default:

                    throw new NotSupportedException(
                        $"Allocation method '{settings.AllocationMethod}' is not supported.");
            }

            row.FfbWeight = weight;

            row.BeginningAllocation = Money.Round(
                settings.BeginningReservePool * weight);

            row.FundRatio =
                row.FFB == 0m
                    ? 0m
                    : row.BeginningAllocation / row.FFB;
        }
    }
}