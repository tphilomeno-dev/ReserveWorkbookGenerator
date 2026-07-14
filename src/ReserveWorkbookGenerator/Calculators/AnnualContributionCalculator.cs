using ReserveWorkbookGenerator.Common;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Calculators;

public class AnnualContributionCalculator
{
    public void Execute(
        IList<ReserveScheduleRow> rows,
        ReserveSettings settings)
    {
        if (rows == null)
            throw new ArgumentNullException(nameof(rows));

        if (settings == null)
            throw new ArgumentNullException(nameof(settings));

        foreach (var row in rows)
        {
            // Remaining Required

            row.RemainingRequired = Money.Round(
                row.Component.ReplacementCost - row.BeginningAllocation);

            if (row.RemainingRequired < 0)
                row.RemainingRequired = 0;

            // Annual Contribution

            if (row.Component.RemainingLife > 0)
            {
                row.AnnualContribution = Money.Round(
                    row.RemainingRequired /
                    row.Component.RemainingLife);
            }
            else
            {
                row.AnnualContribution = 0;
            }

            // Monthly Contribution

            row.MonthlyContribution = Money.Round(
                row.AnnualContribution / 12);

            // Monthly Cost Per Unit

            if (settings.UnitCount > 0)
            {
                row.MonthlyCpu = Money.Round(
                    row.MonthlyContribution /
                    settings.UnitCount);
            }
            else
            {
                row.MonthlyCpu = 0;
            }
        }
    }
}