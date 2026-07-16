using FluentAssertions;
using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Models;
using Xunit;

namespace ReserveWorkbookGenerator.Tests.Calculators;

public class InflationCalculatorTests
{
    [Fact]
    public void Should_Inflate_Replacement_Cost()
    {
        // Arrange

        var component = new ReserveComponent
        {
            Component = "Roof",
            ReplacementCost = 610000m
        };

        var calculator = new InflationCalculator();

        // Act

        calculator.Execute(
            new[] { component },
            0.03m);

        // Assert

        component.ReplacementCost
            .Should()
            .Be(628300m);
    }

    [Fact]
    public void Should_Not_Change_Cost_When_Inflation_Is_Zero()
    {
        var component = new ReserveComponent
        {
            ReplacementCost = 610000m
        };

        var calculator = new InflationCalculator();

        calculator.Execute(
            new[] { component },
            0m);

        component.ReplacementCost
            .Should()
            .Be(610000m);
    }
}