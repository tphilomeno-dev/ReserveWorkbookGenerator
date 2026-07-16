using FluentAssertions;
using ReserveWorkbookGenerator.Engine;
using ReserveWorkbookGenerator.Models;
using Xunit;

namespace ReserveWorkbookGenerator.Tests.Engine;

public class ScenarioComparisonEngineTests
{
    [Fact]
    public void Should_Create_Scenario_Comparison()
    {
        var comparisonEngine =
            new ScenarioComparisonEngine();

        var comparison =
            comparisonEngine.Compare(
            [
                new ProjectionScenario
                {
                    Name = "Baseline"
                },
                new ProjectionScenario
                {
                    Name = "High Inflation"
                }
            ]);

        comparison.Scenarios
            .Should()
            .HaveCount(2);

        comparison.Scenarios[0].Name
            .Should()
            .Be("Baseline");

        comparison.Scenarios[1].Name
            .Should()
            .Be("High Inflation");
    }
}