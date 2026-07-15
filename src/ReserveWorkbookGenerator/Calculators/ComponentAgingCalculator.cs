using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Calculators;

public class ComponentAgingCalculator
{
    public void Execute(
        IList<ReserveComponent> components)
    {
        if (components == null)
            throw new ArgumentNullException(nameof(components));

        foreach (var component in components)
        {
            if (component.RemainingLife > 0)
            {
                component.RemainingLife--;
            }
        }
    }
}