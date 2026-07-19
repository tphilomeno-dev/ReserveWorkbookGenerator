using FluentAssertions;
using ReserveWorkbookGenerator.Financial;
using ReserveWorkbookGenerator.Models;
using Xunit;

namespace ReserveWorkbookGenerator.Tests.Financial;

public class ReserveExpenditureCalculatorTests
{
    [Fact]
    public void Should_Return_Zero_When_No_Component_Is_Due()
    {
        var calculator = new ReserveExpenditureCalculator();

        var components = new[]
        {
            new ReserveComponent
            {
                Name = "Roof",
                RemainingLife = 5,
                ReplacementCost = 600000m
            }
        };

        calculator.Calculate(components)
            .Should()
            .Be(0m);
    }

    [Fact]
    public void Should_Return_Replacement_Cost_When_Component_Is_Due()
    {
        var calculator = new ReserveExpenditureCalculator();

        var components = new[]
        {
            new ReserveComponent
            {
                Name = "Roof",
                RemainingLife = 0,
                ReplacementCost = 600000m
            }
        };

        calculator.Calculate(components)
            .Should()
            .Be(600000m);
    }

    [Fact]
    public void Should_Sum_Multiple_Replacement_Costs()
    {
        var calculator = new ReserveExpenditureCalculator();

        var components = new[]
        {
            new ReserveComponent
            {
                Name = "Roof",
                RemainingLife = 0,
                ReplacementCost = 600000m
            },
            new ReserveComponent
            {
                Name = "Paint",
                RemainingLife = 0,
                ReplacementCost = 150000m
            }
        };

        calculator.Calculate(components)
            .Should()
            .Be(750000m);
    }
    
}