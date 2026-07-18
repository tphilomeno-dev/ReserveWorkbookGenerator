using ClosedXML.Excel;
using ReserveWorkbookGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveWorkbookGenerator.Excel.Sheets
{
    public class ReserveScheduleSheet
    {
        /// <summary>
        /// Builds the Reserve Schedule worksheet.
        /// </summary>
        public static void Build(
            XLWorkbook workbook,
            IEnumerable<ReserveScheduleRow> schedule)
        {
            var worksheet = workbook.Worksheets.Add("02 Reserve Schedule");

            worksheet.Cell("A1").Value = "Category";
            worksheet.Cell("B1").Value = "Reserve Component";
            worksheet.Cell("C1").Value = "Last Replaced";
            worksheet.Cell("D1").Value = "Useful Life";
            worksheet.Cell("E1").Value = "Remaining Life";
            worksheet.Cell("F1").Value = "Replacement Year";
            worksheet.Cell("G1").Value = "Replacement Cost";
            worksheet.Cell("H1").Value = "Beginning Allocation";
            worksheet.Cell("I1").Value = "Fully Funded Balance";
            worksheet.Cell("J1").Value = "Remaining Required";
            worksheet.Cell("K1").Value = "Annual Contribution";
            worksheet.Cell("L1").Value = "Monthly Contribution";
            worksheet.Cell("M1").Value = "Monthly CPU";
            worksheet.Cell("N1").Value = "FFB Weight";

            var row = 2;

            foreach (var item in schedule)
            {
                worksheet.Cell($"A{row}").Value = item.Component.Category;
                worksheet.Cell($"B{row}").Value = item.Component.Component;
                worksheet.Cell($"C{row}").Value = item.Component.LastReplaced;
                worksheet.Cell($"D{row}").Value = item.Component.UsefulLife;
                worksheet.Cell($"E{row}").Value = item.Component.RemainingLife;
                worksheet.Cell($"F{row}").Value = DateTime.Today.Year + item.Component.RemainingLife;
                worksheet.Cell($"G{row}").Value = item.Component.ReplacementCost;
                worksheet.Cell($"H{row}").Value = item.BeginningAllocation;
                worksheet.Cell($"I{row}").Value = item.FFB;
                worksheet.Cell($"J{row}").Value = item.RemainingRequired;
                worksheet.Cell($"K{row}").Value = item.AnnualContribution;
                worksheet.Cell($"L{row}").Value = item.MonthlyContribution;
                worksheet.Cell($"M{row}").Value = item.MonthlyCpu;
                worksheet.Cell($"N{row}").Value = item.FfbWeight;

                row++;
            }

            // Totals Row
            worksheet.Cell($"A{row}").Value = "TOTAL";

            worksheet.Cell($"G{row}").FormulaA1 = $"SUM(G2:G{row - 1})";
            worksheet.Cell($"H{row}").FormulaA1 = $"SUM(H2:H{row - 1})";
            worksheet.Cell($"I{row}").FormulaA1 = $"SUM(I2:I{row - 1})";
            worksheet.Cell($"J{row}").FormulaA1 = $"SUM(J2:J{row - 1})";
            worksheet.Cell($"K{row}").FormulaA1 = $"SUM(K2:K{row - 1})";
            worksheet.Cell($"L{row}").FormulaA1 = $"SUM(L2:L{row - 1})";
            worksheet.Cell($"M{row}").FormulaA1 = $"SUM(M2:M{row - 1})";

            var totalRange = worksheet.Range($"A{row}:N{row}");

            totalRange.Style.Font.Bold = true;
            totalRange.Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
            totalRange.Style.Border.TopBorder = XLBorderStyleValues.Thick;

            worksheet.Range("A1:N1")
                .Style.Font.Bold = true;

            // Freeze the header row
            worksheet.SheetView.FreezeRows(1);

            // Add AutoFilter
            worksheet.Range($"A1:N{row - 1}").SetAutoFilter();

            // Format header row
            var header = worksheet.Range("A1:N1");

            header.Style.Font.Bold = true;
            header.Style.Fill.BackgroundColor = XLColor.LightGray;
            header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            header.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            // Format dates
            worksheet.Column("C").Style.DateFormat.Format = "yyyy";

            // Format currency columns
            foreach (var column in new[] { "G", "H", "I", "J", "K", "L", "M" })
            {
                worksheet.Column(column).Style.NumberFormat.Format = "$#,##0";
            }

            // Format percentage column
            worksheet.Column("N").Style.NumberFormat.Format = "0.00%";

            // Center numeric life/year columns
            foreach (var column in new[] { "D", "E", "F" })
            {
                worksheet.Column(column).Style.Alignment.Horizontal =
                    XLAlignmentHorizontalValues.Center;
            }

            worksheet.Columns().AdjustToContents();
        }
    }
}
