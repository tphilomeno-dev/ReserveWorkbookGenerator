using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Engine;

public class ReserveScheduleBuilder
{
    public List<ReserveScheduleRow> Build(IEnumerable<ReserveComponent> components)
    {
        return components
            .Select(component => new ReserveScheduleRow
            {
                Name =  component
            })
            .ToList();
    }
}