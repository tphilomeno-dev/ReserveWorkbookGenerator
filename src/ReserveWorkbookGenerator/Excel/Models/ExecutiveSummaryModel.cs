using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveWorkbookGenerator.Excel.Models
{
    public sealed class ExecutiveSummaryModel
    {
        public DateTime ReportDate { get; init; }

        public int StudyYear { get; init; }

        public string WorkbookVersion { get; init; } = "";

        public string FundingMethod { get; init; } = "";

        public int ComponentCount { get; init; }

        public decimal TotalReplacementCost { get; init; }

        public decimal BeginningAllocation { get; init; }

        public decimal FullyFundedBalance { get; init; }

        public decimal PercentFunded { get; init; }

        public string FundingLevel { get; init; } = "";

        public decimal AnnualContribution { get; init; }

        public decimal MonthlyContribution { get; init; }

        public decimal MonthlyCostPerUnit { get; init; }
    }
}
