using ReserveWorkbookGenerator.Common;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Calculators;

public class FfbCalculator
{
    public void Execute(IList<ReserveScheduleRow> rows)
    {
        foreach (var row in rows)
        {
            var component = row.Name;

            row.FFB = Calculate(
                component.ReplacementCost,
                component.UsefulLife,
                component.RemainingLife);
        }
    }

    public decimal Calculate(
        decimal replacementCost,
        int usefulLife,
        int remainingLife)
    {
        if (replacementCost <= 0)
            return 0m;

        if (usefulLife <= 0)
            return 0m;

        remainingLife = Math.Clamp(remainingLife, 0, usefulLife);

        decimal consumedLife = usefulLife - remainingLife;

        return Money.Round(
            replacementCost * Money.Divide(consumedLife, usefulLife));
    }
}