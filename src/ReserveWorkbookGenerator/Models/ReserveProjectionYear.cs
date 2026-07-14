namespace ReserveWorkbookGenerator.Models;

public class ReserveProjectionYear
{
    public int Year { get; set; }

    public decimal BeginningPool { get; set; }

    public decimal AnnualContributions { get; set; }

    public decimal InterestEarned { get; set; }

    public decimal ReserveExpenditures { get; set; }

    public decimal EndingPool { get; set; }
}