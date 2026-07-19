namespace ReserveWorkbookGenerator.Models;

public class ReserveComponent
{
    public int Id { get; set; }

    public ReserveType ComponentType { get; set; }

    public string Category { get; set; } = "";
    public string Name { get; set; } = "";

    public int LastReplaced { get; set; }
    public int UsefulLife { get; set; }
    public int RemainingLife { get; set; }

    public decimal ReplacementCost { get; set; }

    public string? Comments { get; set; }
}