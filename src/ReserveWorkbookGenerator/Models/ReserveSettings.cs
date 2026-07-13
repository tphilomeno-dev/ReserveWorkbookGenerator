using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveWorkbookGenerator.Models
{
    public sealed class ReserveSettings
    {
        public int CurrentYear { get; set; }

        public int UnitCount { get; set; }

        public decimal BeginningReservePool { get; set; }

        public decimal AnnualReserveBudget { get; set; }

        public decimal AnnualInterest { get; set; }

        public decimal InflationRate { get; set; }

        public AllocationMethod AllocationMethod { get; set; }
    }
}
