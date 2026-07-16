namespace ReserveWorkbookGenerator.Models;

public class ProjectionSettings
{
    public int NumberOfYears { get; set; }

    public decimal InflationRate { get; set; }

    public decimal InterestRate { get; set; }

    public ReinvestmentPolicy ReinvestmentPolicy { get; set; }
    = ReinvestmentPolicy.AutoRenewSameRate;
}