using System.ComponentModel;
using System.Reflection;

namespace ReserveWorkbookGenerator.Editor.Helpers;

public static class EnumHelper
{
    public static string GetDescription(Enum value)
    {
        var field = value.GetType().GetField(value.ToString());

        var attribute = field?
            .GetCustomAttribute<DescriptionAttribute>();

        return attribute?.Description ?? value.ToString();
    }
}