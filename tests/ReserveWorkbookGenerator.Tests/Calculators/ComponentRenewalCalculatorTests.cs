using FluentAssertions;
using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Models;
using Xunit;

namespace ReserveWorkbookGenerator.Tests.Calculators;

public class ComponentRenewalCalculatorTests
{
    [Fact]
    public void Should_Renew_Component_When_Remaining_Life_Is_Zero()
    {
        // Arrange

        var component = new ReserveComponent
        {
            Component = "Roof",
            RemainingLife = 0,
            UsefulLife = 38,
            LastReplaced = 2006
        };

        var calculator = new ComponentRenewalCalculator();

        // Act

        calculator.Execute(
            new[] { component },
            2026);

        // Assert

        component.RemainingLife.Should().Be(38);
        component.LastReplaced.Should().Be(2026);
    }

    [Fact]
    public void Should_Not_Renew_Component_When_Remaining_Life_Is_Greater_Than_Zero()
    {
        // Arrange

        var component = new ReserveComponent
        {
            Component = "Roof",
            RemainingLife = 5,
            UsefulLife = 38,
            LastReplaced = 2006
        };

        var calculator = new ComponentRenewalCalculator();

        // Act

        calculator.Execute(
            new[] { component },
            2026);

        // Assert

        component.RemainingLife.Should().Be(5);
        component.LastReplaced.Should().Be(2006);
    }
}