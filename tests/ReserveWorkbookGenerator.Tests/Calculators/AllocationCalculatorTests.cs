using FluentAssertions;
using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Tests.Calculators;

public class AllocationCalculatorTests
{
    [Fact]
    public void Execute_Should_Allocate_Beginning_Pool_By_Ffb_Weight()
    {
        // Arrange
        var rows = new List<ReserveScheduleRow>
        {
            new()
            {
                Component = new ReserveComponent
                {
                    Component = "Roof"
                },
                FFB = 200000m
            },
            new()
            {
                Component = new ReserveComponent
                {
                    Component = "Paint"
                },
                FFB = 100000m
            },
            new()
            {
                Component = new ReserveComponent
                {
                    Component = "Pool"
                },
                FFB = 200000m
            }
        };

        var calculator = new AllocationCalculator();

        // Act
        calculator.Execute(rows, 1_000_000m);

        // Assert

        rows[0].FfbWeight.Should().Be(0.40m);
        rows[1].FfbWeight.Should().Be(0.20m);
        rows[2].FfbWeight.Should().Be(0.40m);

        rows[0].BeginningAllocation.Should().Be(400000m);
        rows[1].BeginningAllocation.Should().Be(200000m);
        rows[2].BeginningAllocation.Should().Be(400000m);

        rows.Sum(r => r.BeginningAllocation)
            .Should().Be(1_000_000m);
    }
}