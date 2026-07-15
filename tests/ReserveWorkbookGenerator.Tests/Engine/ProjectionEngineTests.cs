using FluentAssertions;
using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Engine;
using ReserveWorkbookGenerator.Extensions;
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
    [Fact]
    public void Should_Create_Next_Year_From_Current_Year()
    {
        var current = new ReserveProjectionYear
        {
            Year = 2026,
            BeginningPool = 1_250_000m,
            AnnualContributions = 150_000m,
            InterestEarned = 20_000m,
            ReserveExpenditures = 75_000m
        };

        var engine = new ProjectionEngine();

        engine.ProjectOneYear(current);

        var next = engine.CreateNextYear(current);

        next.Year.Should().Be(2027);
        next.BeginningPool.Should().Be(current.EndingPool);
    }
    
    [Fact]
    public void Should_Preserve_Original_Components_When_Projecting()
    {
        // Arrange

        var original = new ReserveComponent
        {
            Id = 1,
            Category = "Roofing",
            Component = "Roof Tiles",
            LastReplaced = 2006,
            UsefulLife = 38,
            RemainingLife = 18,
            ReplacementCost = 610000m
        };

        var originals = new List<ReserveComponent>
    {
        original
    };

        // Act

        var projected = originals
            .Select(c => c.Clone())
            .ToList();

        var agingCalculator = new ComponentAgingCalculator();

        agingCalculator.Execute(projected);

        // Assert

        original.RemainingLife.Should().Be(18);

        projected.Should().HaveCount(1);

        projected[0].RemainingLife.Should().Be(17);

        projected[0].Should().NotBeSameAs(original);
    }
    
    [Fact]
    public void Should_Create_Working_Component_Copy()
    {
        // Arrange

        var projection = new ReserveProjection
        {
            Settings = new ProjectionSettings
            {
                NumberOfYears = 5,
                InterestRate = 0.03m
            }
        };

        projection.SourceComponents.Add(
            new ReserveComponent
            {
                Id = 1,
                Component = "Roof",
                RemainingLife = 18
            });

        var engine = new ProjectionEngine();

        // Act

        engine.Project(projection);

        // Assert

        projection.WorkingComponents.Should().HaveCount(1);

        projection.WorkingComponents[0]
            .Should()
            .NotBeSameAs(projection.SourceComponents[0]);

        projection.WorkingComponents[0].Component
            .Should()
            .Be("Roof");

        projection.SourceComponents[0].RemainingLife
    .Should()
    .Be(18);

        projection.WorkingComponents[0].RemainingLife
            .Should()
            .Be(17);
    }
    [Fact]
    public void Should_Age_Working_Components()
    {
        // Arrange

        var projection = new ReserveProjection
        {
            Settings = new ProjectionSettings()
        };

        projection.SourceComponents.Add(
            new ReserveComponent
            {
                Component = "Roof",
                RemainingLife = 18
            });

        var engine = new ProjectionEngine();

        // Act

        engine.Project(projection);

        // Assert

        projection.SourceComponents[0]
            .RemainingLife.Should().Be(18);

        projection.WorkingComponents.Should().HaveCount(1);

        projection.WorkingComponents[0]
            .RemainingLife.Should().Be(17);

        projection.WorkingComponents[0]
            .Should()
            .NotBeSameAs(projection.SourceComponents[0]);
    }
    [Fact]
    public void Should_Build_Current_Schedule()
    {
        // Arrange

        var projection = new ReserveProjection
        {
            Settings = new ProjectionSettings()
        };

        projection.SourceComponents.Add(
            new ReserveComponent
            {
                Id = 1,
                Category = "Roofing",
                Component = "Roof",
                LastReplaced = 2006,
                UsefulLife = 38,
                RemainingLife = 18,
                ReplacementCost = 610000m
            });

        var reserveSettings = new ReserveSettings
        {
            BeginningReservePool = 1_250_000m,
            UnitCount = 24
        };

        var reserveEngine = new ReserveEngine(
            new ReserveScheduleBuilder(),
            new FfbCalculator(),
            new AllocationCalculator(),
            new AnnualContributionCalculator());

        var engine = new ProjectionEngine();

        // Act

        engine.Project(
            projection,
            reserveEngine,
            reserveSettings);

        // Assert

        projection.CurrentSchedule.Should().HaveCount(1);

        projection.CurrentSchedule[0].Component.Component
            .Should().Be("Roof");

        projection.CurrentSchedule[0].Component.RemainingLife
            .Should().Be(17);
    }
}