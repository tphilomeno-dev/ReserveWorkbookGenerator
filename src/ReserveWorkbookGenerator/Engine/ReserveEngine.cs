using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Engine;

public class ReserveEngine
{
    private readonly ReserveScheduleBuilder _scheduleBuilder;
    private readonly FfbCalculator _ffbCalculator;
    private readonly AllocationCalculator _allocationCalculator;

    public ReserveEngine(
        ReserveScheduleBuilder scheduleBuilder,
        FfbCalculator ffbCalculator,
        AllocationCalculator allocationCalculator)
    {
        _scheduleBuilder = scheduleBuilder;
        _ffbCalculator = ffbCalculator;
        _allocationCalculator = allocationCalculator;
    }

    public List<ReserveScheduleRow> Build(
        IEnumerable<ReserveComponent> components,
        ReserveSettings settings)
    {
        var rows = _scheduleBuilder.Build(components);

        _ffbCalculator.Execute(rows);

        _allocationCalculator.Execute(
            rows,
            settings.BeginningReservePool);

        return rows;
    }
}