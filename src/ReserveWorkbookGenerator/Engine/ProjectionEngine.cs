using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Common;
using ReserveWorkbookGenerator.Extensions;
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
    /// <summary>
    /// Initializes a reserve projection.
    /// </summary>
    public void Project(ReserveProjection projection)
    {
        if (projection == null)
            throw new ArgumentNullException(nameof(projection));

        // Create an independent working copy of the reserve study.
        projection.WorkingComponents = projection.SourceComponents
            .Select(c => c.Clone())
            .ToList();

        // Advance the working copy one year.
        var agingCalculator = new ComponentAgingCalculator();

        agingCalculator.Execute(projection.WorkingComponents);
    }
    /// <summary>
    /// Projects the reserve study one year and builds the current reserve schedule.
    /// </summary>
    public void Project(
        ReserveProjection projection,
        ReserveEngine reserveEngine,
        ReserveSettings reserveSettings)
    {
        if (projection == null)
            throw new ArgumentNullException(nameof(projection));

        if (reserveEngine == null)
            throw new ArgumentNullException(nameof(reserveEngine));

        if (reserveSettings == null)
            throw new ArgumentNullException(nameof(reserveSettings));

        //
        // Build the working copy.
        //

        Project(projection);

        //
        // Build the reserve schedule for the aged components.
        //

        projection.CurrentSchedule =
            reserveEngine.Build(
                projection.WorkingComponents,
                reserveSettings);
    }
}