using ReserveWorkbookGenerator.Common;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Engine;

public class ProjectionEngine
{
    /// <summary>
    /// Calculates the financial results for a single budget year.
    /// </summary>
    public void ProjectOneYear(ReserveProjectionYear year)
    {
        if (year == null)
            throw new ArgumentNullException(nameof(year));

        year.EndingPool = Money.Round(
            year.BeginningPool
            + year.AnnualContributions
            + year.InterestEarned
            - year.ReserveExpenditures);
    }

    /// <summary>
    /// Creates the next projection year using the previous year's ending pool.
    /// </summary>
    public ReserveProjectionYear CreateNextYear(
        ReserveProjectionYear currentYear)
    {
        if (currentYear == null)
            throw new ArgumentNullException(nameof(currentYear));

        return new ReserveProjectionYear
        {
            Year = currentYear.Year + 1,
            BeginningPool = currentYear.EndingPool,

            // These values will be populated by ProjectYears().
            AnnualContributions = 0m,
            InterestEarned = 0m,
            ReserveExpenditures = 0m,
            EndingPool = 0m
        };
    }

    /// <summary>
    /// Projects the reserve pool for the requested number of years.
    /// </summary>
    public List<ReserveProjectionYear> ProjectYears(
        ProjectionSettings settings,
        ReserveProjectionYear firstYear)
    {
        if (settings == null)
            throw new ArgumentNullException(nameof(settings));

        if (firstYear == null)
            throw new ArgumentNullException(nameof(firstYear));

        if (settings.NumberOfYears <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(settings.NumberOfYears));

        var years = new List<ReserveProjectionYear>();

        var current = firstYear;

        for (int i = 0; i < settings.NumberOfYears; i++)
        {
            ProjectOneYear(current);

            years.Add(current);

            if (i < settings.NumberOfYears - 1)
            {
                var next = CreateNextYear(current);

                //
                // For now we assume constant annual contributions
                // and calculate interest using the beginning pool.
                //

                next.AnnualContributions =
                    firstYear.AnnualContributions;

                next.InterestEarned =
                    Money.Round(
                        next.BeginningPool
                        * settings.InterestRate);

                next.ReserveExpenditures = 0m;

                current = next;
            }
        }

        return years;
    }
}