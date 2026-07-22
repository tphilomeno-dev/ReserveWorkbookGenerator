namespace ReserveWorkbookGenerator.Editor.UndoRedo;

public interface IUndoableAction
{
    void Undo();
    void Redo();
}