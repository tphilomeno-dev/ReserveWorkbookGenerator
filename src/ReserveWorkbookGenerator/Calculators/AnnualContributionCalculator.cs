using ReserveWorkbookGenerator.Common;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Calculators;

public class AnnualContributionCalculator
{
    public void Execute(IList<ReserveScheduleRow> rows,ReserveSettings settings)
    {
        if (rows == null)
            throw new ArgumentNullException(nameof(rows));

        foreach (var row in rows)
        {
            //
            // Remaining Required is based on today's replacement cost.
            // If the analytical allocation already exceeds the current
            // replacement cost, there is no current funding need.
            //
            row.RemainingRequired = Math.Max(
                0,
                row.Name.ReplacementCost - row.BeginningAllocation);

            //
            // Fully funded (or over-funded) components receive no
            // additional contribution this year.
            //
            if (row.RemainingRequired == 0)
            {
                row.AnnualContribution = 0;
                row.MonthlyContribution = 0;
                row.MonthlyCpu = 0;
                continue;
            }

            //
            // Calculate the annual contribution required to fully fund
            // the component over its remaining life.
            //
            // Component is due this year.
            if (row.Name.RemainingLife <= 0)
            {
                row.AnnualContribution = row.RemainingRequired;
            }
            else
            {
                row.AnnualContribution = Money.Round(
                    row.RemainingRequired / row.Name.RemainingLife);
            }

            row.MonthlyContribution = Money.Round(
                row.AnnualContribution / 12);

            row.MonthlyCpu = Money.Round(
                row.MonthlyContribution / settings.UnitCount);
        }
    }
}