namespace ReserveWorkbookGenerator.Models;

public class ProjectionSettings
{
    public int StartYear { get; set; }

    public int NumberOfYears { get; set; }

    public decimal InflationRate { get; set; }

    public decimal InterestRate { get; set; }
}