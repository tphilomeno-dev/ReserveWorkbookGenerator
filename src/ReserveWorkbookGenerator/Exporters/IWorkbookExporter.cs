using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Exporters;

public interface IWorkbookExporter
{
    void Export(
        string fileName,
        IEnumerable<ReserveScheduleRow> schedule);
}