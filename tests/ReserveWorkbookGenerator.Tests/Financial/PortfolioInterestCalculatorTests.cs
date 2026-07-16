using FluentAssertions;
using ReserveWorkbookGenerator.Financial;
using ReserveWorkbookGenerator.Models;
using Xunit;

namespace ReserveWorkbookGenerator.Tests.Financial;

public class PortfolioInterestCalculatorTests
{
    [Fact]
    public void Should_Calculate_Portfolio_Interest()
    {
        // Arrange

        var portfolio = new InvestmentPortfolio();

        portfolio.Accounts.Add(new InvestmentAccount
        {
            Institution = "Bank A",
            Balance = 300000m,
            InterestRate = 0.04m
        });

        portfolio.Accounts.Add(new InvestmentAccount
        {
            Institution = "Bank B",
            Balance = 250000m,
            InterestRate = 0.035m
        });

        portfolio.Accounts.Add(new InvestmentAccount
        {
            Institution = "Money Market",
            Balance = 500000m,
            InterestRate = 0.02m
        });

        var calculator = new PortfolioInterestCalculator();

        // Act

        var interest = calculator.Calculate(portfolio);

        // Assert

        interest.Should().Be(30750m);
    }
}