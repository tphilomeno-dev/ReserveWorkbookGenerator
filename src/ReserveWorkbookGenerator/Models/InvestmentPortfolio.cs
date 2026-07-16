namespace ReserveWorkbookGenerator.Models;

/// <summary>
/// Represents the reserve fund investment portfolio.
/// </summary>
public sealed class InvestmentPortfolio
{
    public List<InvestmentAccount> Accounts { get; } = [];
}