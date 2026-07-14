using FluentAssertions;
using ReserveWorkbookGenerator.Engine;
using ReserveWorkbookGenerator.Models;
using Xunit;

namespace ReserveWorkbookGenerator.Tests.Engine;

public class ProjectionEngineTests
{
    [Fact]
    public void Should_Project_One_Year()
    {
        var engine = new ProjectionEngine();

        var year = new ReserveProjectionYear
        {
            Year = 2026,
            BeginningPool = 1_250_000m,
            AnnualContributions = 150_000m,
            InterestEarned = 20_000m,
            ReserveExpenditures = 75_000m
        };

        engine.ProjectOneYear(year);

        year.EndingPool.Should().Be(1_345_000m);
    }
    [Fact]
    public void Should_Roll_Forward_To_Next_Year()
    {
        var engine = new ProjectionEngine();

        var year2026 = new ReserveProjectionYear
        {
            Year = 2026,
            BeginningPool = 1_250_000m,
            AnnualContributions = 150_000m,
            InterestEarned = 20_000m,
            ReserveExpenditures = 75_000m
        };

        engine.ProjectOneYear(year2026);

        var year2027 = engine.CreateNextYear(year2026);

        year2027.Year.Should().Be(2027);
        year2027.BeginningPool.Should().Be(1_345_000m);
    }
    [Fact]
    public void Should_Project_Multiple_Years()
    {
        var engine = new ProjectionEngine();

        var settings = new ProjectionSettings
        {
            NumberOfYears = 3,
            InterestRate = 0.03m,
            InflationRate = 0.00m
        };

        var firstYear = new ReserveProjectionYear
        {
            Year = 2026,
            BeginningPool = 1_250_000m,
            AnnualContributions = 150_000m,
            InterestEarned = 20_000m,
            ReserveExpenditures = 75_000m
        };

        var years = engine.ProjectYears(
            settings,
            firstYear);

        years.Should().HaveCount(3);

        years[0].Year.Should().Be(2026);
        years[1].Year.Should().Be(2027);
        years[2].Year.Should().Be(2028);

        years[0].EndingPool.Should().Be(1_345_000m);
        years[1].BeginningPool.Should().Be(1_345_000m);
    }
}