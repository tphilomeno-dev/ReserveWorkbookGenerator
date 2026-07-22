using ReserveWorkbookGenerator.Editor.UndoRedo;

public sealed class UndoManager
{
    private readonly Stack<IUndoableAction> _undoStack = new();
    private readonly Stack<IUndoableAction> _redoStack = new();

    public void Execute(IUndoableAction action)
    {
        _undoStack.Push(action);
        _redoStack.Clear();
    }

    public void Undo()
    {
        if (_undoStack.Count == 0)
            return;

        var action = _undoStack.Pop();
        action.Undo();
        _redoStack.Push(action);
    }

    public void Redo()
    {
        if (_redoStack.Count == 0)
            return;

        var action = _redoStack.Pop();
        action.Redo();
        _undoStack.Push(action);
    }
}