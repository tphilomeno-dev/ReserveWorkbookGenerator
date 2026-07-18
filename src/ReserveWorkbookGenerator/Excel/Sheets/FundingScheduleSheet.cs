using ClosedXML.Excel;
using ReserveWorkbookGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveWorkbookGenerator.Excel.Sheets
{
    public class FundingScheduleSheet
    {
        public static void Build(
    XLWorkbook workbook,
    IEnumerable<ReserveScheduleRow> schedule)
        {
            var worksheet = workbook.Worksheets.Add("03 Reserve Funding");
            worksheet.Cell("A1").Value = "Reserve Component";
            worksheet.Cell("B1").Value = "Beginning Allocation";
            worksheet.Cell("C1").Value = "Fully Funded Balance";
            worksheet.Cell("D1").Value = "Fund Ratio";
            worksheet.Cell("E1").Value = "Remaining Required";
            worksheet.Cell("F1").Value = "Annual Contribution";
            worksheet.Cell("G1").Value = "Monthly Contribution";
            worksheet.Cell("H1").Value = "Monthly CPU";

            var row = 2;

            foreach (var item in schedule)
            {
                worksheet.Cell($"A{row}").Value = item.Component.Component;
                worksheet.Cell($"B{row}").Value = item.BeginningAllocation;
                worksheet.Cell($"C{row}").Value = item.FFB;
                worksheet.Cell($"D{row}").Value = item.FundRatio;
                worksheet.Cell($"E{row}").Value = item.RemainingRequired;
                worksheet.Cell($"F{row}").Value = item.AnnualContribution;
                worksheet.Cell($"G{row}").Value = item.MonthlyContribution;
                worksheet.Cell($"H{row}").Value = item.MonthlyCpu;

                row++;
            }
            // Formatting
            worksheet.Column("D").Style.NumberFormat.Format = "0.0%";
        }
    }
}
