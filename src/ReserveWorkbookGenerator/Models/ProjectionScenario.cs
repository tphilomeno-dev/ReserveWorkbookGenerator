namespace ReserveWorkbookGenerator.Models;

/// <summary>
/// Represents a complete reserve projection scenario.
/// </summary>
public sealed class ProjectionScenario
{
    /// <summary>
    /// Scenario name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Optional description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Projection settings.
    /// </summary>
    public ProjectionSettings ProjectionSettings { get; init; } = new();

    /// <summary>
    /// Reserve settings.
    /// </summary>
    public ReserveSettings ReserveSettings { get; init; } = new();

    /// <summary>
    /// Reserve components used for this scenario.
    /// </summary>
    public List<ReserveComponent> Components { get; } = [];

    /// <summary>
    /// Optional investment portfolio.
    /// </summary>
    public InvestmentPortfolio? InvestmentPortfolio { get; set; }

    /// <summary>
    /// Projection results.
    /// </summary>
    public ReserveProjection? Projection { get; set; }
}