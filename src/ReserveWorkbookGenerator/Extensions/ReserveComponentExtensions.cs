using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Extensions;

public static class ReserveComponentExtensions
{
    public static ReserveComponent Clone(
        this ReserveComponent component)
    {
        return new ReserveComponent
        {
            Id = component.Id,
            Category = component.Category,
            Name = component.Name,
            LastReplaced = component.LastReplaced,
            UsefulLife = component.UsefulLife,
            RemainingLife = component.RemainingLife,
            ReplacementCost = component.ReplacementCost,
            Comments = component.Comments
        };
    }
}