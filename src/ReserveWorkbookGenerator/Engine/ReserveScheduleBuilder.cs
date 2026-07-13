using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Engine;

public class ReserveScheduleBuilder
{
    public List<ReserveScheduleRow> Build(
        IEnumerable<ReserveComponent> components)
    {
        return components
            .Select(c => new ReserveScheduleRow
            {
                Component = c
            })
            .ToList();
    }
}