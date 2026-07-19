using ReserveWorkbookGenerator.Common;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Calculators;

public class AllocationCalculator
{
	public void Execute(
		IList<ReserveScheduleRow> rows,
		decimal beginningReservePool)
	{
		if (rows == null)
			throw new ArgumentNullException(nameof(rows));

		if (!rows.Any())
			return;

		decimal totalFfb = rows.Sum(r => r.FFB);

		if (totalFfb <= 0)
			return;

		foreach (var row in rows)
		{
			row.FfbWeight = Money.Divide(row.FFB, totalFfb);

            row.BeginningAllocation = Money.Round(
					beginningReservePool * row.FfbWeight);

            row.FundRatio =
                row.FFB == 0m
                    ? 0m
                    : row.BeginningAllocation / row.FFB;
        }

        // Components are capped at their funding target.
        // Any remaining reserve balance is treated as
        // an unallocated reserve surplus and is reported
        // separately.
    }
}