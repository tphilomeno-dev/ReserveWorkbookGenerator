using FluentAssertions;
using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Engine;
using ReserveWorkbookGenerator.Financial;
using ReserveWorkbookGenerator.Models;
using Xunit;

namespace ReserveWorkbookGenerator.Tests.Engine;

public class ScenarioEngineTests
{
    [Fact]
    public void Should_Execute_Scenario()
    {
        // Arrange

        var scenario = new ProjectionScenario
        {
            Name = "Baseline"
        };

        scenario.ProjectionSettings.NumberOfYears = 1;
        scenario.ProjectionSettings.InterestRate = 0.03m;

        scenario.ReserveSettings.BeginningReservePool = 1_250_000m;
        scenario.ReserveSettings.UnitCount = 24;

        scenario.Components.Add(
            new ReserveComponent
            {
                Id = 1,
                Category = "Roofing",
                Name = "Roof",
                RemainingLife = 18,
                UsefulLife = 38,
                ReplacementCost = 610000m
            });

        var reserveEngine = new ReserveEngine(
            new ReserveScheduleBuilder(),
            new FfbCalculator(),
            new AllocationCalculator(),
            new AnnualContributionCalculator());

        var projectionEngine = new ProjectionEngine();

        var fundingEngine = new FundingAnalysisEngine();

        var scenarioEngine = new ScenarioEngine(
            projectionEngine,
            fundingEngine);

        // Act

        scenarioEngine.Execute(
            scenario,
            reserveEngine);

        // Assert

        scenario.Projection.Should().NotBeNull();

        scenario.Projection!.Years.Should().HaveCount(1);

        scenario.Projection.Years[0]
            .FullyFundedBalance
            .Should()
            .BeGreaterThan(0m);

        scenario.Projection.Years[0]
            .PercentFunded
            .Should()
            .BeGreaterThan(0m);
    }
}