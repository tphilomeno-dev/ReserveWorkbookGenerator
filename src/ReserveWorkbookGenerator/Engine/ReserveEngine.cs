using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Engine;

public class ReserveEngine
{
    private readonly ReserveScheduleBuilder _scheduleBuilder;
    private readonly FfbCalculator _ffbCalculator;

    public ReserveEngine(
        ReserveScheduleBuilder scheduleBuilder,
        FfbCalculator ffbCalculator)
    {
        _scheduleBuilder = scheduleBuilder;
        _ffbCalculator = ffbCalculator;
    }

    public List<ReserveScheduleRow> Build(
        IEnumerable<ReserveComponent> components)
    {
        var rows = _scheduleBuilder.Build(components);

        _ffbCalculator.Execute(rows);

        return rows;
    }
}