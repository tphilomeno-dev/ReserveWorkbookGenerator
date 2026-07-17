namespace ReserveWorkbookGenerator.Models;

/// <summary>
/// General information describing a reserve study.
/// This information is informational only and is not used
/// in reserve funding calculations.
/// </summary>
public sealed class StudyInfo
{
    /// <summary>
    /// Name of the condominium or homeowners association.
    /// </summary>
    public string AssociationName { get; set; } = string.Empty;

    /// <summary>
    /// Optional description of the property.
    /// </summary>
    public string PropertyDescription { get; set; } = string.Empty;

    /// <summary>
    /// Date the reserve study was prepared.
    /// </summary>
    public DateOnly StudyDate { get; set; }

    /// <summary>
    /// Person or organization that prepared the study.
    /// </summary>
    public string PreparedBy { get; set; } = string.Empty;

    /// <summary>
    /// Version or revision identifier.
    /// </summary>
    public string Version { get; set; } = "1.0";

    /// <summary>
    /// Optional notes about the study.
    /// </summary>
    public string Notes { get; set; } = string.Empty;
}