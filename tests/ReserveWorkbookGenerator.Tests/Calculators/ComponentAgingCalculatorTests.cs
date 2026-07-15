using FluentAssertions;
using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Models;
using Xunit;

namespace ReserveWorkbookGenerator.Tests.Calculators;

public class ComponentAgingCalculatorTests
{
    [Fact]
    public void Should_Decrease_Remaining_Life_By_One_Year()
    {
        var component = new ReserveComponent
        {
            RemainingLife = 18
        };

        var calculator = new ComponentAgingCalculator();

        calculator.Execute(new[] { component });

        component.RemainingLife.Should().Be(17);
    }

    [Fact]
    public void Should_Not_Decrease_Below_Zero()
    {
        var component = new ReserveComponent
        {
            RemainingLife = 0
        };

        var calculator = new ComponentAgingCalculator();

        calculator.Execute(new[] { component });

        component.RemainingLife.Should().Be(0);
    }
}