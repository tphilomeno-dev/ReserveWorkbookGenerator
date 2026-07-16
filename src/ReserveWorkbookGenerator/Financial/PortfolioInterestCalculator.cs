using ReserveWorkbookGenerator.Common;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Financial;

/// <summary>
/// Calculates annual interest earned by an investment portfolio.
/// </summary>
public class PortfolioInterestCalculator
{
    public decimal Calculate(
        InvestmentPortfolio portfolio)
    {
        ArgumentNullException.ThrowIfNull(portfolio);

        return Money.Round(
            portfolio.Accounts.Sum(a =>
                a.Balance * a.InterestRate));
    }
}