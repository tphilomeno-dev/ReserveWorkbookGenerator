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

			row.BeginningAllocation =
				Money.Round(beginningReservePool * row.FfbWeight);
		}

		//
		// Fix any rounding difference by adjusting the last row.
		//

		decimal allocated = rows.Sum(r => r.BeginningAllocation);

		decimal difference = beginningReservePool - allocated;

		if (difference != 0)
		{
			rows[^1].BeginningAllocation += difference;
		}
	}
}