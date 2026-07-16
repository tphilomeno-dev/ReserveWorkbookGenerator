namespace ReserveWorkbookGenerator.Models;

/// <summary>
/// Represents a single reserve investment.
/// </summary>
public sealed class InvestmentAccount
{
    public string Institution { get; set; } = "";

    public string AccountName { get; set; } = "";

    public decimal Balance { get; set; }

    public decimal InterestRate { get; set; }

    public DateOnly? MaturityDate { get; set; }

    public bool AutoRenew { get; set; }

    public int TermInMonths { get; set; }
}