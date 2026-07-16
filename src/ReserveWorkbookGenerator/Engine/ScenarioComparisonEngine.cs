using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Engine;

/// <summary>
/// Builds scenario comparisons.
/// </summary>
public class ScenarioComparisonEngine
{
    public ScenarioComparison Compare(
        IEnumerable<ProjectionScenario> scenarios)
    {
        ArgumentNullException.ThrowIfNull(scenarios);

        var comparison = new ScenarioComparison();

        comparison.Scenarios.AddRange(scenarios);

        return comparison;
    }
}