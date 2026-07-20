using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Editor.State;

public sealed class EditorState
{
    /// <summary>
    /// The currently loaded reserve study.
    /// </summary>
    public ReserveStudy? Study { get; set; }

    /// <summary>
    /// Full path of the currently open JSON file.
    /// </summary>
    public string? FileName { get; set; }

    /// <summary>
    /// Indicates whether there are unsaved changes.
    /// </summary>
    public bool IsDirty { get; set; }

    /// <summary>
    /// True when a study has been loaded.
    /// </summary>
    public bool HasStudy => Study is not null;

    /// <summary>
    /// File name without the path, or "Untitled" if no file is open.
    /// </summary>
    public string DisplayName =>
        string.IsNullOrWhiteSpace(FileName)
            ? "Untitled"
            : Path.GetFileName(FileName);

    /// <summary>
    /// Clears the current editor state.
    /// </summary>
    public void Clear()
    {
        Study = null;
        FileName = null;
        IsDirty = false;
    }
}