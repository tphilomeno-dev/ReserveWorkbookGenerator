using FluentAssertions;
using ReserveWorkbookGenerator.Analysis;
using ReserveWorkbookGenerator.Models;
using Xunit;

namespace ReserveWorkbookGenerator.Tests.Analysis;

public class FundingLevelAnalyzerTests
{
    [Theory]
    [InlineData(0.10, FundingLevel.Weak)]
    [InlineData(0.30, FundingLevel.Fair)]
    [InlineData(0.50, FundingLevel.Fair)]
    [InlineData(0.70, FundingLevel.Strong)]
    [InlineData(1.25, FundingLevel.Strong)]
    public void Should_Classify_Funding_Level(
        decimal percentFunded,
        FundingLevel expected)
    {
        // Arrange

        var analyzer = new FundingLevelAnalyzer();

        // Act

        var level = analyzer.Calculate(percentFunded);

        // Assert

        level.Should().Be(expected);
    }
}