using FluentAssertions;
using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Tests.Calculators;

public class AnnualContributionCalculatorTests
{
    [Fact]
    public void Execute_Should_Calculate_Annual_Contribution()
    {
        // Arrange

        var rows = new List<ReserveScheduleRow>
        {
            new()
            {
                Name = new ReserveComponent
                {
                    Name = "Roof",
                    RemainingLife = 10
                },

                BeginningAllocation = 300000m,
                FFB = 300000m
            }
        };

        rows[0].Name.ReplacementCost = 500000m;

        var settings = new ReserveSettings
        {
            UnitCount = 24
        };

        var calculator = new AnnualContributionCalculator();

        // Act

        calculator.Execute(rows, settings);

        // Assert

        rows[0].RemainingRequired.Should().Be(200000m);

        rows[0].AnnualContribution.Should().Be(20000m);

        rows[0].MonthlyContribution.Should().Be(1666.67m);

        rows[0].MonthlyCpu.Should().Be(69.44m);
    }

    [Fact]
    public void Execute_Should_Not_Produce_Negative_Remaining_Required()
    {
        var rows = new List<ReserveScheduleRow>
        {
            new()
            {
                Name = new ReserveComponent
                {
                    RemainingLife = 10,
                    ReplacementCost = 500000m
                },

                BeginningAllocation = 600000m
            }
        };

        var settings = new ReserveSettings
        {
            UnitCount = 24
        };

        var calculator = new AnnualContributionCalculator();

        calculator.Execute(rows, settings);

        rows[0].RemainingRequired.Should().Be(0m);
        rows[0].AnnualContribution.Should().Be(0m);
        rows[0].MonthlyContribution.Should().Be(0m);
        rows[0].MonthlyCpu.Should().Be(0m);
    }
}