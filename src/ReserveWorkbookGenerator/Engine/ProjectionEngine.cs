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

            // These will be calculated or supplied later.
            AnnualContributions = 0m,
            InterestEarned = 0m,
            ReserveExpenditures = 0m,
            EndingPool = 0m
        };
    }
    public List<ReserveProjectionYear> ProjectYears(
    ReserveProjectionYear firstYear,
    int numberOfYears)
    {
        if (firstYear == null)
            throw new ArgumentNullException(nameof(firstYear));

        if (numberOfYears <= 0)
            throw new ArgumentOutOfRangeException(nameof(numberOfYears));

        var years = new List<ReserveProjectionYear>();

        var current = firstYear;

        for (int i = 0; i < numberOfYears; i++)
        {
            ProjectOneYear(current);

            years.Add(current);

            if (i < numberOfYears - 1)
            {
                current = CreateNextYear(current);
            }
        }

        return years;
    }
}