using FluentAssertions;
using ReserveWorkbookGenerator.Analysis;
using ReserveWorkbookGenerator.Models;
using Xunit;

namespace ReserveWorkbookGenerator.Tests.Analysis;

public class FundingTrendAnalyzerTests
{
    [Theory]
    [InlineData(0.70, 0.60, FundingTrend.Improving)]
    [InlineData(0.60, 0.60, FundingTrend.Stable)]
    [InlineData(0.50, 0.60, FundingTrend.Declining)]
    public void Should_Classify_Funding_Trend(
        decimal currentPercent,
        decimal previousPercent,
        FundingTrend expected)
    {
        // Arrange

        var analyzer = new FundingTrendAnalyzer();

        // Act

        var trend = analyzer.Calculate(
            currentPercent,
            previousPercent);

        // Assert

        trend.Should().Be(expected);
    }
}