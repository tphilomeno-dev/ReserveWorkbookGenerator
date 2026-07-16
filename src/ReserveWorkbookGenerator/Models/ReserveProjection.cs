namespace ReserveWorkbookGenerator.Models;

public sealed class ReserveProjection
{
    /// <summary>
    /// Projection assumptions.
    /// </summary>
    public ProjectionSettings Settings { get; set; } = new();

    /// <summary>
    /// Reserve funding assumptions used to build reserve schedules.
    /// </summary>
    public ReserveSettings ReserveSettings { get; set; } = new();
    /// <summary>
    /// Original reserve study components.
    /// These are never modified during a projection.
    /// </summary>
    public List<ReserveComponent> SourceComponents { get; set; } = new();

    /// <summary>
    /// Working copy of the reserve components.
    /// These components evolve as the projection advances.
    /// </summary>
    public List<ReserveComponent> WorkingComponents { get; set; } = new();

    /// <summary>
    /// Financial summary for each projected year.
    /// </summary>
    public List<ReserveProjectionYear> Years { get; set; } = new();

    public InvestmentPortfolio? InvestmentPortfolio { get; set; }
}