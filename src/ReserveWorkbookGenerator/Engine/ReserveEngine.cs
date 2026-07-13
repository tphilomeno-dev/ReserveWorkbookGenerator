using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Engine;

public class ReserveEngine
{
    private readonly FfbCalculator _ffbCalculator;

    public ReserveEngine(
        FfbCalculator ffbCalculator)
    {
        _ffbCalculator = ffbCalculator;
    }

    public List<ReserveScheduleRow> Build(
        IEnumerable<ReserveComponent> components)
    {
        var rows =
            components
                .Select(c => new ReserveScheduleRow
                {
                    Component = c
                })
                .ToList();

        _ffbCalculator.Execute(rows);

        return rows;
    }
}