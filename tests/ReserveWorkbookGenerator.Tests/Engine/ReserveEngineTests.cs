using FluentAssertions;
using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Engine;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Tests.Engine;

public class ReserveEngineTests
{
    [Fact]
    public void Build_Should_Create_Schedule_With_Ffb()
    {
        // Arrange
        var components = new List<ReserveComponent>
        {
            new()
            {
                Id = 1,
                Category = "Roofing",
                Component = "Roof",
                LastReplaced = 2006,
                UsefulLife = 30,
                RemainingLife = 20,
                ReplacementCost = 600000m
            },
            new()
            {
                Id = 2,
                Category = "Painting",
                Component = "Paint",
                LastReplaced = 2022,
                UsefulLife = 8,
                RemainingLife = 4,
                ReplacementCost = 160000m
            }
        };

        var engine = new ReserveEngine(
                new ReserveScheduleBuilder(),
                new FfbCalculator(),
                new AllocationCalculator());

        var settings = new ReserveSettings
        {
            BeginningReservePool = 1_000_000m
        };

        // Act
        var schedule = engine.Build(
            components,
            settings);

        // Assert

        schedule.Should().HaveCount(2);

        schedule[0].Component.Component.Should().Be("Roof");
        schedule[0].FFB.Should().Be(200000m);
        schedule[0].Component.Category.Should().Be("Roofing");
        schedule[0].Component.ReplacementCost.Should().Be(600000m);

        schedule[1].Component.UsefulLife.Should().Be(8);
        schedule[1].Component.Component.Should().Be("Paint");
        schedule[1].FFB.Should().Be(80000m);
    }
}