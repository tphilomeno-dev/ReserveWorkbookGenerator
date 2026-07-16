using FluentAssertions;
using ReserveWorkbookGenerator.Engine;
using ReserveWorkbookGenerator.Models;
using Xunit;

namespace ReserveWorkbookGenerator.Tests.Engine;

public class FundingAnalysisEngineTests
{
    [Fact]
    public void Should_Analyze_A_Projection_Year()
    {
        // Arrange

        var projection = new ReserveProjection();

        projection.Years.Add(
            new ReserveProjectionYear
            {
                EndingPool = 500000m,
                Schedule =
                [
                    new ReserveScheduleRow
                    {
                        FFB = 250000m
                    }
                ]
            });

        var engine = new FundingAnalysisEngine();

        // Act

        engine.Analyze(projection);

        // Assert

        projection.Years[0].FullyFundedBalance
            .Should().Be(250000m);

        projection.Years[0].PercentFunded
            .Should().Be(2.0m);

        projection.Years[0].FundingLevel
            .Should().Be(FundingLevel.Strong);
    }
}