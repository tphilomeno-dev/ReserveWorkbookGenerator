using ClosedXML.Excel;
using ReserveWorkbookGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveWorkbookGenerator.Excel.Sheets
{
    public class FundingScheduleSheet
    {
        private const string WorksheetName = "03 Funding Schedule";

        private const int HeaderRow = 1;
        private const int FirstDataRow = 2;
        private const int ColumnCount = 8;
        /// <summary>
        /// Builds the Reserve Funding worksheet.
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

            FormatWorksheet(
                worksheet,
                lastDataRow);
        }
        /// <summary>
        /// Writes the worksheet column headers.
        /// </summary>
        private static void WriteHeaders(
            IXLWorksheet worksheet)
        {
            ArgumentNullException.ThrowIfNull(worksheet);

            string[] headers =
            {
                "Reserve Component",
                "Beginning Allocation",
                "Fully Funded Balance",
                "Fund Ratio",
                "Remaining Required",
                "Annual Contribution",
                "Monthly Contribution",
                "Monthly CPU"
            };

            for (int column = 0; column < headers.Length; column++)
            {
                worksheet.Cell(HeaderRow, column + 1).Value = headers[column];
            }
        }

        /// <summary>
        /// Writes the worksheet detail rows.
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
                worksheet.Cell(row, 1).Value = item.Component.Component;
                worksheet.Cell(row, 2).Value = item.BeginningAllocation;
                worksheet.Cell(row, 3).Value = item.FFB;
                worksheet.Cell(row, 4).Value = item.FundRatio;
                worksheet.Cell(row, 5).Value = item.RemainingRequired;
                worksheet.Cell(row, 6).Value = item.AnnualContribution;
                worksheet.Cell(row, 7).Value = item.MonthlyContribution;
                worksheet.Cell(row, 8).Value = item.MonthlyCpu;

                row++;
            }

            return row - 1;
        }

        /// <summary>
        /// Applies formatting to the Reserve Funding worksheet.
        /// </summary>
        private static void FormatWorksheet(
            IXLWorksheet worksheet,
            int lastDataRow)
        {
            ArgumentNullException.ThrowIfNull(worksheet);

            // Freeze the header row.
            worksheet.SheetView.FreezeRows(HeaderRow);

            // Enable filtering.
            worksheet.Range(
                HeaderRow,
                1,
                lastDataRow,
                ColumnCount)
                .SetAutoFilter();

            // Format the header row.
            ExcelStyles.ApplySectionHeader(
                worksheet.Range(
                    HeaderRow,
                    1,
                    HeaderRow,
                    ColumnCount));

            // Format currency columns.
            foreach (var column in new[] { 2, 3, 5, 6, 7, 8 })
            {
                worksheet.Column(column).Style.NumberFormat.Format =
                    ExcelFormats.Currency;
            }

            // Format percentage column.
            worksheet.Column(4).Style.NumberFormat.Format =
                ExcelFormats.Percent;

            // Center the percentage column.
            worksheet.Column(4).Style.Alignment.Horizontal =
                XLAlignmentHorizontalValues.Center;

            // Auto-size all columns.
            worksheet.Columns().AdjustToContents();
        }
    }
}
