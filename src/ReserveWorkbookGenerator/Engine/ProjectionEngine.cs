using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Common;
using ReserveWorkbookGenerator.Extensions;
using ReserveWorkbookGenerator.Financial;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Engine;

public class ProjectionEngine
{
    /// <summary>
    /// Calculates the financial results for a single budget year.
    /// </summary>
    private readonly FixedRateInterestCalculator _interestCalculator = new();
    private readonly ReserveExpenditureCalculator _reserveExpenditureCalculator = new();
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
    private void InitializeProjection(
        ReserveProjection projection)
    {
        if (projection == null)
            throw new ArgumentNullException(nameof(projection));

        // Create an independent working copy of the reserve study.
        projection.WorkingComponents = projection.SourceComponents
            .Select(c => c.Clone())
            .ToList();
    }
    /// <summary>
    /// Projects the reserve study one year and builds the current reserve schedule.
    /// </summary>
    public void Project(
        ReserveProjection projection,
        ReserveEngine scheduleEngine)
    {
        if (projection == null)
            throw new ArgumentNullException(nameof(projection));

        if (scheduleEngine == null)
            throw new ArgumentNullException(nameof(scheduleEngine));
        if (projection.Settings.NumberOfYears <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(projection.Settings.NumberOfYears),
                "NumberOfYears must be greater than zero.");
        }
        //
        // Build the working copy.
        //

        InitializeProjection(projection);

        //
        // Create yearly snapshots.
        //

        projection.Years.Clear();

        var currentYear = DateTime.Now.Year;

        for (int i = 0; i < projection.Settings.NumberOfYears; i++)
        {
            var schedule = scheduleEngine.Build(
                projection.WorkingComponents,
                projection.ReserveSettings);
            var annualContributions =
                schedule.Sum(r => r.AnnualContribution);
            decimal beginningPool;

            if (i == 0)
            {
                beginningPool =
                    projection.ReserveSettings.BeginningReservePool;
            }
            else
            {
                beginningPool =
                    projection.Years[i - 1].EndingPool;
            }

            var interestEarned =
                _interestCalculator.Calculate(
                    beginningPool,
                    projection.Settings.InterestRate);

            var reserveExpenditures =
                _reserveExpenditureCalculator.Calculate(
                    projection.WorkingComponents);
            var endingPool =
                Money.Round(
                    beginningPool
                    + annualContributions
                    + interestEarned
                    - reserveExpenditures);

            projection.Years.Add(
                CreateProjectionYear(
                    currentYear + i,
                    schedule,
                    beginningPool,
                    annualContributions,
                    interestEarned,
                    reserveExpenditures,
                    endingPool));


            if (i < projection.Settings.NumberOfYears - 1)
            {
                AdvanceWorkingComponents(projection);
            }
        }
    }
    private void AdvanceWorkingComponents(
    ReserveProjection projection)
    {
        var agingCalculator = new ComponentAgingCalculator();

        agingCalculator.Execute(projection.WorkingComponents);
    }
    /// <summary>
    /// Creates a yearly projection snapshot.
    /// </summary>
    private ReserveProjectionYear CreateProjectionYear(
        int year,
        List<ReserveScheduleRow> reserveSchedule,
        decimal beginningPool,
        decimal annualContributions,
        decimal interestEarned,
        decimal reserveExpenditures,
        decimal endingPool)
    {
        
        return new ReserveProjectionYear
        {
            Year = year,

            BeginningPool = beginningPool,
            AnnualContributions = annualContributions,
            InterestEarned = interestEarned,
            EndingPool = endingPool,
            ReserveExpenditures = reserveExpenditures,

            Schedule = reserveSchedule
        .Select(r => r.Clone())
        .ToList()
        };
    }
}