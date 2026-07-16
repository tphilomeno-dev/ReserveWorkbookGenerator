namespace ReserveWorkbookGenerator.Models;

/// <summary>
/// Represents the comparison of multiple scenarios.
/// </summary>
public sealed class ScenarioComparison
{
    public List<ProjectionScenario> Scenarios { get; } = [];
}