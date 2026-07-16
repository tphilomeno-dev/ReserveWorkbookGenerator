using FluentAssertions;
using ReserveWorkbookGenerator.Analysis;
using ReserveWorkbookGenerator.Models;
using Xunit;

namespace ReserveWorkbookGenerator.Tests.Analysis;

public class InvestmentMaturityAnalyzerTests
{
    [Fact]
    public void Should_Detect_Maturity_During_Projection_Year()
    {
        // Arrange

        var account = new InvestmentAccount
        {
            MaturityDate = new DateOnly(2027, 6, 15)
        };

        var analyzer = new InvestmentMaturityAnalyzer();

        // Act

        var matures = analyzer.MaturesInYear(
            account,
            2027);

        // Assert

        matures.Should().BeTrue();
    }

    [Fact]
    public void Should_Not_Detect_Maturity_In_Different_Year()
    {
        var account = new InvestmentAccount
        {
            MaturityDate = new DateOnly(2028, 6, 15)
        };

        var analyzer = new InvestmentMaturityAnalyzer();

        var matures = analyzer.MaturesInYear(
            account,
            2027);

        matures.Should().BeFalse();
    }
}