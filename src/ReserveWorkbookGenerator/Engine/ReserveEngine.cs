using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Engine;

public class ReserveEngine
{
    private readonly ReserveScheduleBuilder _scheduleBuilder;
    private readonly FfbCalculator _ffbCalculator;
    private readonly AllocationCalculator _allocationCalculator;
    private readonly AnnualContributionCalculator _annualContributionCalculator;

    public ReserveEngine(
        ReserveScheduleBuilder scheduleBuilder,
        FfbCalculator ffbCalculator,
        AllocationCalculator allocationCalculator,
        AnnualContributionCalculator annualContributionCalculator)
    {
        _scheduleBuilder = scheduleBuilder;
        _ffbCalculator = ffbCalculator;
        _allocationCalculator = allocationCalculator;
        _annualContributionCalculator = annualContributionCalculator;
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

        _annualContributionCalculator.Execute(rows,
            settings);

        return rows;
    }
}