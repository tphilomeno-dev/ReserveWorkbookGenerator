using FluentAssertions;
using ReserveWorkbookGenerator.Financial;
using Xunit;

namespace ReserveWorkbookGenerator.Tests.Financial;

public class FixedRateInterestCalculatorTests
{
    [Fact]
    public void Should_Calculate_Annual_Interest()
    {
        // Arrange

        var calculator = new FixedRateInterestCalculator();

        // Act

        var interest = calculator.Calculate(
            1_250_000m,
            0.03m);

        // Assert

        interest.Should().Be(37_500m);
    }
    [Fact]
    public void Should_Return_Zero_When_Beginning_Pool_Is_Zero()
    {
        var calculator = new FixedRateInterestCalculator();

        var interest = calculator.Calculate(
            0m,
            0.03m);

        interest.Should().Be(0m);
    }
}