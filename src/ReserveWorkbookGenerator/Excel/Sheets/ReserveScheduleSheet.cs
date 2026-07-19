using ClosedXML.Excel;
using ReserveWorkbookGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveWorkbookGenerator.Excel.Sheets
{
    public class ReserveScheduleSheet
    {
        private const string WorksheetName = "03 Reserve Schedule";

        private const int HeaderRow = 1;
        private const int FirstDataRow = 2;
        /// <summary>
        /// Builds the Reserve Schedule worksheet.
        /// </summary>
        /// <summary>
        /// Builds the Reserve Schedule worksheet.
        /// </summary>
        public static void Build(
            XLWorkbook workbook,
            IEnumerable<ReserveScheduleRow> schedule)
        {
            ArgumentNullException.ThrowIfNull(workbook);
            ArgumentNullException.ThrowIfNull(schedule);

            var worksheet = workbook.Worksheets.Add(WorksheetName);

            WriteHeaders(worksheet);

            var lastDataRow = WriteDetailRows(
                worksheet,
                schedule);

            var totalRow = lastDataRow + 1;

            WriteTotals(
                worksheet,
                totalRow);

            FormatWorksheet(
                worksheet,
                totalRow);
        }
        /// <summary>
        /// Writes the Reserve Schedule column headers.
        /// </summary>
        private static void WriteHeaders(
            IXLWorksheet worksheet)
        {
            ArgumentNullException.ThrowIfNull(worksheet);

            string[] headers =
            {
        "Category",
        "Name",
        "Last Replaced",
        "Useful Life",
        "Remaining Life",
        "Replacement Year",
        "Replacement Cost",
        "Beginning Allocation",
        "Fully Funded Balance",
        "Remaining Required",
        "Annual Contribution",
        "Monthly Contribution",
        "Monthly CPU",
        "FFB Weight"
    };

            for (int column = 0; column < headers.Length; column++)
            {
                worksheet.Cell(HeaderRow, column + 1).Value = headers[column];
            }
        }

        /// <summary>
        /// Writes the Reserve Schedule detail rows.
        /// </summary>
        private static int WriteDetailRows(
            IXLWorksheet worksheet,
            IEnumerable<ReserveScheduleRow> schedule)
        {
            ArgumentNullException.ThrowIfNull(worksheet);
            ArgumentNullException.ThrowIfNull(schedule);

            var row = FirstDataRow;

            foreach (var item in schedule)
            {
                worksheet.Cell(row, 1).Value = item.Name.Category;
                worksheet.Cell(row, 2).Value = item.Name.Name;
                worksheet.Cell(row, 3).Value = item.Name.LastReplaced;
                worksheet.Cell(row, 4).Value = item.Name.UsefulLife;
                worksheet.Cell(row, 5).Value = item.Name.RemainingLife;
                worksheet.Cell(row, 6).Value =
                    DateTime.Today.Year + item.Name.RemainingLife;
                worksheet.Cell(row, 7).Value = item.Name.ReplacementCost;
                worksheet.Cell(row, 8).Value = item.BeginningAllocation;
                worksheet.Cell(row, 9).Value = item.FFB;
                worksheet.Cell(row, 10).Value = item.RemainingRequired;
                worksheet.Cell(row, 11).Value = item.AnnualContribution;
                worksheet.Cell(row, 12).Value = item.MonthlyContribution;
                worksheet.Cell(row, 13).Value = item.MonthlyCpu;
                worksheet.Cell(row, 14).Value = item.FfbWeight;

                row++;
            }

            return row - 1;
        }

        /// <summary>
        /// Writes the totals row for the Reserve Schedule worksheet.
        /// </summary>
        private static void WriteTotals(
            IXLWorksheet worksheet,
            int totalRow)
        {
            ArgumentNullException.ThrowIfNull(worksheet);

            worksheet.Cell(totalRow, 1).Value = "TOTAL";

            foreach (var column in new[] { 7, 8, 9, 10, 11, 12, 13 })
            {
                var columnLetter = XLHelper.GetColumnLetterFromNumber(column);

                worksheet.Cell(totalRow, column).FormulaA1 =
                    $"SUM({columnLetter}{FirstDataRow}:{columnLetter}{totalRow - 1})";
            }
        }

        /// <summary>
        /// Applies formatting to the Reserve Schedule worksheet.
        /// </summary>
        private static void FormatWorksheet(
            IXLWorksheet worksheet,
            int totalRow)
        {
            ArgumentNullException.ThrowIfNull(worksheet);

            // Freeze the header row.
            worksheet.SheetView.FreezeRows(HeaderRow);

            // Enable filtering.
            worksheet.Range(
                HeaderRow,
                1,
                totalRow - 1,
                14)
                .SetAutoFilter();

            // Format the header row.
            ExcelStyles.ApplySectionHeader(
                worksheet.Range(HeaderRow, 1, HeaderRow, 14));

            // Format the totals row.
            ExcelStyles.ApplyTotalsRow(
                worksheet.Range(totalRow, 1, totalRow, 14));

            // Year column.
            worksheet.Column(3).Style.Alignment.Horizontal =
     XLAlignmentHorizontalValues.Center;

            // Currency columns.
            foreach (var column in new[] { 7, 8, 9, 10, 11, 12, 13 })
            {
                worksheet.Column(column).Style.NumberFormat.Format =
                    ExcelFormats.Currency;
            }

            // Percentage column.
            worksheet.Column(14).Style.NumberFormat.Format =
                ExcelFormats.Percent2;

            // Center numeric columns.
            foreach (var column in new[] { 3, 4, 5, 6 })
            {
                worksheet.Column(column)
                    .Style.Alignment.Horizontal =
                    XLAlignmentHorizontalValues.Center;
            }

            worksheet.Columns().AdjustToContents();
        }
    }
}
