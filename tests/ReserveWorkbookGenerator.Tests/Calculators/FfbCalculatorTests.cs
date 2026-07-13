using FluentAssertions;
using ReserveWorkbookGenerator.Calculators;


namespace ReserveWorkbookGenerator.Tests.Calculators;

public class FfbCalculatorTests
{
    [Fact]
    public void Calculate_Should_Return_Correct_Ffb()
    {
        var calculator = new FfbCalculator();

        decimal result = calculator.Calculate(
            replacementCost: 600000m,
            usefulLife: 30,
            remainingLife: 20);

        result.Should().Be(200000m);
    }
}