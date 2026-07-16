using FluentAssertions;
using ReserveWorkbookGenerator.Analysis;
using ReserveWorkbookGenerator.Models;
using Xunit;

namespace ReserveWorkbookGenerator.Tests.Analysis;

public class FullyFundedBalanceAnalyzerTests
{
    [Fact]
    public void Should_Calculate_Portfolio_Fully_Funded_Balance()
    {
        // Arrange

        var analyzer = new FullyFundedBalanceAnalyzer();

        var schedule = new List<ReserveScheduleRow>
        {
            new()
            {
                FFB = 244000m
            },
            new()
            {
                FFB = 82500m
            },
            new()
            {
                FFB = 148200m
            }
        };

        // Act

        var ffb = analyzer.Calculate(schedule);

        // Assert

        ffb.Should().Be(474700m);
    }
}