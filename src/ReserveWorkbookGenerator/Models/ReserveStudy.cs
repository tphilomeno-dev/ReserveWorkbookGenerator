

namespace ReserveWorkbookGenerator.Models;

public sealed class ReserveStudy
{
    public StudyInfo Study { get; set; } = new();

    public ReserveSettings Settings { get; set; } = new();

    public List<ReserveComponent> Components { get; set; } = new();

    // Component Collections
    public IEnumerable<ReserveComponent> SirsComponents =>
        Components.Where(c => c.Type == ReserveType.Sirs);

    public IEnumerable<ReserveComponent> NonSirsComponents =>
        Components.Where(c => c.Type == ReserveType.NonSirs);

    // Summary Counts
    public int SirsComponentCount => SirsComponents.Count();

    public int NonSirsComponentCount => NonSirsComponents.Count();

    // Replacement Costs
    public decimal TotalReplacementCost =>
        Components.Sum(c => c.ReplacementCost);

    public decimal SirsReplacementCost =>
        SirsComponents.Sum(c => c.ReplacementCost);

    public decimal NonSirsReplacementCost =>
        NonSirsComponents.Sum(c => c.ReplacementCost);
}