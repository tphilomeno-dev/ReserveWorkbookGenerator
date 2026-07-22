using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ReserveWorkbookGenerator.Models
{
    public enum AllocationMethod
    {
        [Description("Percent of Replacement Cost")]
        PercentOfReplacementCost,

        [Description("Fully Funded Balance (FFB)")]
        FullyFundedBalance,

        [Description("Manual")]
        Manual
    }
}
