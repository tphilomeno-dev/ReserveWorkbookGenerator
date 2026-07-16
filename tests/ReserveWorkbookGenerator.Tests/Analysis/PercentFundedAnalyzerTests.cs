using FluentAssertions;
using ReserveWorkbookGenerator.Analysis;
using Xunit;

namespace ReserveWorkbookGenerator.Tests.Analysis;

public class PercentFundedAnalyzerTests
{
    [Fact]
    public void Should_Calculate_Percent_Funded()
    {
        // Arrange

        var analyzer = new PercentFundedAnalyzer();

        // Act

        var percent = analyzer.Calculate(
            1_250_000m,
            1_000_000m);

        // Assert

        percent.Should().Be(1.25m);
    }

    [Fact]
    public void Should_Return_Zero_When_Fully_Funded_Balance_Is_Zero()
    {
        var analyzer = new PercentFundedAnalyzer();

        var percent = analyzer.Calculate(
            1_250_000m,
            0m);

        percent.Should().Be(0m);
    }
}