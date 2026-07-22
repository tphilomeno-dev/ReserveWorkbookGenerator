using System.Text.Json.Serialization;

namespace ReserveWorkbookGenerator.Models;

public sealed class ReserveStudy
{
    public StudyInfo Study { get; set; } = new();

    public ReserveSettings Settings { get; set; } = new();

    public List<ReserveComponent> Components { get; set; } = new();

    // Component Collections

    [JsonIgnore]
    public IEnumerable<ReserveComponent> SirsComponents =>
        Components.Where(c => c.Type == ReserveType.Sirs);

    [JsonIgnore]
    public IEnumerable<ReserveComponent> NonSirsComponents =>
        Components.Where(c => c.Type == ReserveType.NonSirs);

    // Summary Counts

    [JsonIgnore]
    public int SirsComponentCount => SirsComponents.Count();

    [JsonIgnore]
    public int NonSirsComponentCount => NonSirsComponents.Count();

    // Replacement Costs

    [JsonIgnore]
    public decimal TotalReplacementCost =>
        Components.Sum(c => c.ReplacementCost);

    [JsonIgnore]
    public decimal SirsReplacementCost =>
        SirsComponents.Sum(c => c.ReplacementCost);

    [JsonIgnore]
    public decimal NonSirsReplacementCost =>
        NonSirsComponents.Sum(c => c.ReplacementCost);
}