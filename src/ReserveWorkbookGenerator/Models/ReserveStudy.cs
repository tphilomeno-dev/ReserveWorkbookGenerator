namespace ReserveWorkbookGenerator.Models;

public sealed class ReserveStudy
{
    public StudyInfo Study { get; set; } = new();

    public ReserveSettings Settings { get; set; } = new();

    public List<ReserveComponent> Components { get; set; } = new();
}