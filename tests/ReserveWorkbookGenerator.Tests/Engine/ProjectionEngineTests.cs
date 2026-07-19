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
            Name = "Roof Tiles",
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
    public void Should_Create_First_Projection_Year()
    {
        // Arrange

        var projection = new ReserveProjection
        {
            Settings = new ProjectionSettings
            {
                NumberOfYears = 1
            },
            ReserveSettings = new ReserveSettings
            {
                BeginningReservePool = 1_250_000m,
                UnitCount = 24
            }
        };

        projection.SourceComponents.Add(
            new ReserveComponent
            {
                Id = 1,
                Category = "Roofing",
                Name = "Roof",
                LastReplaced = 2006,
                UsefulLife = 38,
                RemainingLife = 18,
                ReplacementCost = 610000m
            });

        var reserveEngine = new ReserveEngine(
            new ReserveScheduleBuilder(),
            new FfbCalculator(),
            new AllocationCalculator(),
            new AnnualContributionCalculator());

        var engine = new ProjectionEngine();

        // Act

        engine.Project(
            projection,
            reserveEngine);

        // Assert

        projection.Years.Should().HaveCount(1);

        var year = projection.Years[0];

        year.Schedule.Should().HaveCount(1);

        year.Schedule[0].Name.Name
            .Should().Be("Roof");

        year.Schedule[0].Name.RemainingLife
            .Should().Be(18);
    }
    [Fact]
    public void Should_Create_Multiple_Projection_Years()
    {
        // Arrange

        var projection = new ReserveProjection
        {
            Settings = new ProjectionSettings
            {
                NumberOfYears = 5
            },
            ReserveSettings = new ReserveSettings
            {
                BeginningReservePool = 1_250_000m,
                UnitCount = 24
            }
        };

        projection.SourceComponents.Add(
            new ReserveComponent
            {
                Id = 1,
                Category = "Roofing",
                Name = "Roof",
                LastReplaced = 2006,
                UsefulLife = 38,
                RemainingLife = 18,
                ReplacementCost = 610000m
            });

        var reserveEngine = new ReserveEngine(
            new ReserveScheduleBuilder(),
            new FfbCalculator(),
            new AllocationCalculator(),
            new AnnualContributionCalculator());

        var engine = new ProjectionEngine();

        // Act

        engine.Project(
            projection,
            reserveEngine);

        // Assert

        projection.Years.Should().HaveCount(5);

        projection.Years[0].Schedule[0].Name.RemainingLife.Should().Be(18);
        projection.Years[1].Schedule[0].Name.RemainingLife.Should().Be(17);
        projection.Years[2].Schedule[0].Name.RemainingLife.Should().Be(16);
        projection.Years[3].Schedule[0].Name.RemainingLife.Should().Be(15);
        projection.Years[4].Schedule[0].Name.RemainingLife.Should().Be(14);
    }
    [Fact]
    public void Should_Calculate_Annual_Contributions_From_Schedule()
    {
        // Arrange

        var projection = new ReserveProjection
        {
            Settings = new ProjectionSettings
            {
                NumberOfYears = 1
            },
            ReserveSettings = new ReserveSettings
            {
                BeginningReservePool = 1_250_000m,
                UnitCount = 24
            }
        };

        projection.SourceComponents.Add(
            new ReserveComponent
            {
                Id = 1,
                Category = "Roofing",
                Name = "Roof",
                LastReplaced = 2006,
                UsefulLife = 38,
                RemainingLife = 18,
                ReplacementCost = 610000m
            });

        var reserveEngine = new ReserveEngine(
            new ReserveScheduleBuilder(),
            new FfbCalculator(),
            new AllocationCalculator(),
            new AnnualContributionCalculator());

        var engine = new ProjectionEngine();

        // Act

        engine.Project(
            projection,
            reserveEngine);

        // Assert

        var expectedContribution =
            projection.Years[0].Schedule.Sum(r => r.AnnualContribution);

        projection.Years[0].AnnualContributions
            .Should()
            .Be(expectedContribution);
    }
    [Fact]
    public void Should_Calculate_Interest_For_Projection_Year()
    {
        // Arrange

        var projection = new ReserveProjection
        {
            Settings = new ProjectionSettings
            {
                NumberOfYears = 1,
                InterestRate = 0.03m
            },
            ReserveSettings = new ReserveSettings
            {
                BeginningReservePool = 1_250_000m,
                UnitCount = 24
            }
        };

        projection.SourceComponents.Add(
            new ReserveComponent
            {
                Id = 1,
                Category = "Roofing",
                Name = "Roof",
                LastReplaced = 2006,
                UsefulLife = 38,
                RemainingLife = 18,
                ReplacementCost = 610000m
            });

        var reserveEngine = new ReserveEngine(
            new ReserveScheduleBuilder(),
            new FfbCalculator(),
            new AllocationCalculator(),
            new AnnualContributionCalculator());

        var engine = new ProjectionEngine();

        // Act

        engine.Project(
            projection,
            reserveEngine);

        // Assert

        projection.Years.Should().HaveCount(1);

        projection.Years[0].InterestEarned
            .Should()
            .Be(37_500m);
    }
    [Fact]
    public void Should_Carry_Ending_Pool_To_Next_Year()
    {
        // Arrange

        var projection = new ReserveProjection
        {
            Settings = new ProjectionSettings
            {
                NumberOfYears = 2,
                InterestRate = 0.03m
            },
            ReserveSettings = new ReserveSettings
            {
                BeginningReservePool = 1_250_000m,
                UnitCount = 24
            }
        };

        projection.SourceComponents.Add(
            new ReserveComponent
            {
                Id = 1,
                Category = "Roofing",
                Name = "Roof",
                LastReplaced = 2006,
                UsefulLife = 38,
                RemainingLife = 18,
                ReplacementCost = 610000m
            });

        var reserveEngine = new ReserveEngine(
            new ReserveScheduleBuilder(),
            new FfbCalculator(),
            new AllocationCalculator(),
            new AnnualContributionCalculator());

        var engine = new ProjectionEngine();

        // Act

        engine.Project(
            projection,
            reserveEngine);

        // Assert

        projection.Years.Should().HaveCount(2);

        projection.Years[1].BeginningPool
            .Should()
            .Be(projection.Years[0].EndingPool);
    }
    [Fact]
    public void Should_Not_Replace_Component_With_One_Year_Remaining()
    {
        // Arrange

        var component = new ReserveComponent
        {
            Name = "Roof",
            RemainingLife = 1,
            ReplacementCost = 100000m
        };

        // This test will evolve as we implement
        // ReserveExpenditureCalculator.
    }
    [Fact]
    public void Should_Record_Reserve_Expenditure_When_Component_Is_Due()
    {
        // Arrange

        var projection = new ReserveProjection
        {
            Settings = new ProjectionSettings
            {
                NumberOfYears = 1,
                InterestRate = 0.03m
            },
            ReserveSettings = new ReserveSettings
            {
                BeginningReservePool = 1_250_000m,
                UnitCount = 24
            }
        };

        projection.SourceComponents.Add(
            new ReserveComponent
            {
                Id = 1,
                Category = "Roofing",
                Name = "Roof",
                RemainingLife = 0,
                UsefulLife = 38,
                ReplacementCost = 600000m
            });

        var reserveEngine = new ReserveEngine(
            new ReserveScheduleBuilder(),
            new FfbCalculator(),
            new AllocationCalculator(),
            new AnnualContributionCalculator());

        var engine = new ProjectionEngine();

        // Act

        engine.Project(
            projection,
            reserveEngine);

        // Assert

        projection.Years.Should().HaveCount(1);

        projection.Years[0].ReserveExpenditures
            .Should()
            .Be(600000m);
    }
    [Fact]
    public void Should_Not_Replace_Component_Two_Years_In_A_Row()
    {
        // Arrange

        var projection = new ReserveProjection
        {
            Settings = new ProjectionSettings
            {
                NumberOfYears = 2,
                InterestRate = 0.03m
            },
            ReserveSettings = new ReserveSettings
            {
                BeginningReservePool = 1_250_000m,
                UnitCount = 24
            }
        };

        projection.SourceComponents.Add(
            new ReserveComponent
            {
                Id = 1,
                Category = "Roofing",
                Name = "Roof",
                RemainingLife = 0,
                UsefulLife = 38,
                ReplacementCost = 600000m
            });

        var reserveEngine = new ReserveEngine(
            new ReserveScheduleBuilder(),
            new FfbCalculator(),
            new AllocationCalculator(),
            new AnnualContributionCalculator());

        var engine = new ProjectionEngine();

        // Act

        engine.Project(
            projection,
            reserveEngine);

        // Assert

        projection.Years.Should().HaveCount(2);

        projection.Years[0].ReserveExpenditures
            .Should().Be(600000m);

        projection.Years[1].ReserveExpenditures
            .Should().Be(0m);
    }
    [Fact]
    public void Should_Use_Portfolio_Interest_When_Portfolio_Is_Present()
    {
        // Arrange

        var projection = new ReserveProjection
        {
            Settings = new ProjectionSettings
            {
                NumberOfYears = 1
            },
            ReserveSettings = new ReserveSettings
            {
                BeginningReservePool = 500000m,
                UnitCount = 24
            },
            InvestmentPortfolio = new InvestmentPortfolio()
        };

        projection.InvestmentPortfolio.Accounts.Add(
            new InvestmentAccount
            {
                Institution = "Bank A",
                Balance = 500000m,
                InterestRate = 0.04m
            });

        projection.SourceComponents.Add(
            new ReserveComponent
            {
                Id = 1,
                Category = "Roofing",
                Name = "Roof",
                RemainingLife = 10,
                UsefulLife = 30,
                ReplacementCost = 600000m
            });

        var reserveEngine = new ReserveEngine(
            new ReserveScheduleBuilder(),
            new FfbCalculator(),
            new AllocationCalculator(),
            new AnnualContributionCalculator());

        var engine = new ProjectionEngine();

        // Act

        engine.Project(
            projection,
            reserveEngine);

        // Assert

        projection.Years.Should().HaveCount(1);

        projection.Years[0].InterestEarned
            .Should().Be(20000m);
    }
}