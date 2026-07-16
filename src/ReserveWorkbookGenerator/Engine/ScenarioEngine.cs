using ReserveWorkbookGenerator.Extensions;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Engine;

/// <summary>
/// Executes reserve projection scenarios.
/// </summary>
public class ScenarioEngine
{
    private readonly ProjectionEngine _projectionEngine;
    private readonly FundingAnalysisEngine _fundingAnalysisEngine;

    public ScenarioEngine(
        ProjectionEngine projectionEngine,
        FundingAnalysisEngine fundingAnalysisEngine)
    {
        _projectionEngine = projectionEngine;
        _fundingAnalysisEngine = fundingAnalysisEngine;
    }

    public void Execute(
        ProjectionScenario scenario,
        ReserveEngine reserveEngine)
    {
        ArgumentNullException.ThrowIfNull(scenario);
        ArgumentNullException.ThrowIfNull(reserveEngine);

        var projection = new ReserveProjection
        {
            Settings = scenario.ProjectionSettings,
            ReserveSettings = scenario.ReserveSettings,
            InvestmentPortfolio = scenario.InvestmentPortfolio
        };

        projection.SourceComponents.AddRange(
            scenario.Components.Select(c => c.Clone()));

        _projectionEngine.Project(
            projection,
            reserveEngine);

        _fundingAnalysisEngine.Analyze(
            projection);

        scenario.Projection = projection;
    }
}