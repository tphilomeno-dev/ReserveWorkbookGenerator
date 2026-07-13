namespace ReserveWorkbookGenerator.Models;

public sealed class ReserveComponent
{
    /// <summary>
    /// Permanent identifier for the reserve component.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Roofing, Painting, Structural, etc.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Display name.
    /// </summary>
    public string Component { get; set; } = string.Empty;

    /// <summary>
    /// Last year this component was replaced.
    /// </summary>
    public int LastReplaced { get; set; }

    /// <summary>
    /// Estimated useful life in years.
    /// </summary>
    public int UsefulLife { get; set; }

    /// <summary>
    /// Remaining life from the latest reserve study.
    /// </summary>
    public int RemainingLife { get; set; }

    /// <summary>
    /// Current replacement cost.
    /// </summary>
    public decimal ReplacementCost { get; set; }

    /// <summary>
    /// Optional notes.
    /// </summary>
    public string Comments { get; set; } = string.Empty;
}