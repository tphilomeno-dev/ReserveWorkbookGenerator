using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveWorkbookGenerator.Models
{
    public sealed class ReserveSettings
    {
        public int StudyYear { get; set; }

        public int UnitCount { get; set; }

        public decimal BeginningReservePool { get; set; }

        public decimal InterestRate { get; set; }

        public decimal InflationRate { get; set; }

        public AllocationMethod AllocationMethod { get; set; }
            = AllocationMethod.FullyFundedBalance;
    }
}
