using System.Reflection;

namespace ReserveWorkbookGenerator.Editor.UndoRedo;

public sealed class PropertyChangeAction : IUndoableAction
{
    private readonly object _target;
    private readonly PropertyInfo _property;
    private readonly object? _oldValue;
    private readonly object? _newValue;

    public PropertyChangeAction(
        object target,
        string propertyName,
        object? oldValue,
        object? newValue)
    {
        _target = target;

        _property = target.GetType().GetProperty(propertyName)
            ?? throw new ArgumentException(
                $"Property '{propertyName}' not found.");

        _oldValue = oldValue;
        _newValue = newValue;
    }

    public void Undo()
    {
        _property.SetValue(_target, _oldValue);
    }

    public void Redo()
    {
        _property.SetValue(_target, _newValue);
    }
}