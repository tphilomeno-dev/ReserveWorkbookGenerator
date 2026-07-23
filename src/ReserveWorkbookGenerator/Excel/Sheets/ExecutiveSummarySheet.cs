using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using ReserveWorkbookGenerator.Extensions;
using ReserveWorkbookGenerator.Analysis;
using ReserveWorkbookGenerator.Excel.Models;
using ReserveWorkbookGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveWorkbookGenerator.Excel.Sheets
{

    public class ExecutiveSummarySheet
    {
        // ----------------------------------------------------------------------
        // Workbook Constants
        // ----------------------------------------------------------------------

        private const string CurrentWorkbookVersion = "1.3.0";

        // ----------------------------------------------------------------------
        // Formatting Constants
        // ----------------------------------------------------------------------

        private const string CurrencyFormat = "$#,##0";
        private const string PercentFormat = "0.0%";
        private const string ShortDateFormat = "MM/dd/yyyy";
        /// <summary>
        /// Builds the Executive Summary worksheet.
        /// </summary>
        public static void Build(
        XLWorkbook workbook,
        IEnumerable<ReserveScheduleRow> schedule,
        ReserveSettings settings)
        {
            var worksheet = workbook.Worksheets.Add("02 Executive Summary");

            var summary = BuildExecutiveSummaryModel(schedule, settings);

            WriteTitle(worksheet);

            WriteReportInformation(worksheet, summary);

            WriteCurrentReservePosition(worksheet, summary);

            WriteFundingRecommendation(worksheet, summary);

            WriteFundingAssessment(worksheet, summary);

            FormatExecutiveSummary(worksheet);

            WriteFooter(worksheet);

            worksheet.Columns().AdjustToContents();
        }
        private static ExecutiveSummaryModel BuildExecutiveSummaryModel(
            IEnumerable<ReserveScheduleRow> schedule,
            ReserveSettings settings)
        {
            var rows = schedule.ToList();

            var totalReplacementCost =
                rows.Sum(x => x.Name.ReplacementCost);

            var beginningAllocation =
                rows.Sum(x => x.BeginningAllocation);

            var fullyFundedBalance =
                rows.Sum(x => x.FFB);

            var annualContribution =
                rows.Sum(x => x.AnnualContribution);

            var monthlyContribution =
                rows.Sum(x => x.MonthlyContribution);

            var monthlyCpu =
                rows.Sum(x => x.MonthlyCpu);

            var percentFunded =
                fullyFundedBalance == 0
                    ? 0
                    : beginningAllocation / fullyFundedBalance;

            var fundingAnalyzer = new FundingLevelAnalyzer();

            return new ExecutiveSummaryModel
            {
                ReportDate = DateTime.Now,

                StudyYear = settings.StudyYear,

                WorkbookVersion = "1.3.0",

                FundingMethod = settings.AllocationMethod.GetDescription(),

                ComponentCount = rows.Count,

                TotalReplacementCost = totalReplacementCost,

                BeginningAllocation = beginningAllocation,

                FullyFundedBalance = fullyFundedBalance,

                PercentFunded = percentFunded,

                FundingLevel =
                    fundingAnalyzer.Calculate(percentFunded).ToString(),

                AnnualContribution = annualContribution,

                MonthlyContribution = monthlyContribution,

                MonthlyCostPerUnit = monthlyCpu
            };
        }
    
    /// <summary>
    /// Writes the Current Reserve Position section of the Executive Summary worksheet.
    /// </summary>
    private static void WriteCurrentReservePosition(
        IXLWorksheet worksheet,
        ExecutiveSummaryModel summary)
        {
            ArgumentNullException.ThrowIfNull(worksheet);
            ArgumentNullException.ThrowIfNull(summary);

            worksheet.Cell("A13").Value = "Current Reserve Position";

            worksheet.Cell("A15").Value = "Total Replacement Cost";
            worksheet.Cell("C15").Value = summary.TotalReplacementCost;

            worksheet.Cell("A16").Value = "Beginning Reserve Balance";
            worksheet.Cell("C16").Value = summary.BeginningAllocation;

            worksheet.Cell("A17").Value = "Fully Funded Balance";
            worksheet.Cell("C17").Value = summary.FullyFundedBalance;

            worksheet.Cell("A18").Value = "Percent Funded (Beginning Reserve ÷ FFB)";
            worksheet.Cell("C18").Value = summary.PercentFunded;

            worksheet.Cell("A19").Value = "Funding Level";
            worksheet.Cell("C19").Value = summary.FundingLevel;
        }
        /// <summary>
        /// Writes the Funding Recommendation section of the Executive Summary worksheet.
        /// </summary>
        private static void WriteFundingRecommendation(
            IXLWorksheet worksheet,
            ExecutiveSummaryModel summary)
        {
            ArgumentNullException.ThrowIfNull(worksheet);
            ArgumentNullException.ThrowIfNull(summary);

            worksheet.Cell("A21").Value = "Funding Recommendation";

            worksheet.Cell("A23").Value = "Annual Contribution";
            worksheet.Cell("C23").Value = summary.AnnualContribution;

            worksheet.Cell("A24").Value = "Monthly Contribution";
            worksheet.Cell("C24").Value = summary.MonthlyContribution;

            worksheet.Cell("A25").Value = "Monthly Cost Per Unit";
            worksheet.Cell("C25").Value = summary.MonthlyCostPerUnit;
        }
        /// <summary>
        /// Writes the Funding Assessment section of the Executive Summary worksheet.
        /// </summary>
        private static void WriteFundingAssessment(
            IXLWorksheet worksheet,
            ExecutiveSummaryModel summary)
        {
            ArgumentNullException.ThrowIfNull(worksheet);
            ArgumentNullException.ThrowIfNull(summary);

            worksheet.Cell("A27").Value = "Funding Assessment";

            worksheet.Cell("A29").Value = "Current Funding Level";
            worksheet.Cell("C29").Value = summary.FundingLevel;
        }
        /// <summary>
        /// Applies formatting to the Executive Summary worksheet.
        /// </summary>
        private static void FormatExecutiveSummary(IXLWorksheet worksheet)
        {
            ArgumentNullException.ThrowIfNull(worksheet);

            //
            // Report Titles
            //
            worksheet.Range("A1:D1").Merge();
            worksheet.Range("A2:D2").Merge();
            worksheet.Range("A3:D3").Merge();

            worksheet.Range("A1:A3").Style.Font.Bold = true;

            worksheet.Cell("A1").Style.Font.FontSize = 20;
            worksheet.Cell("A2").Style.Font.FontSize = 16;
            worksheet.Cell("A3").Style.Font.FontSize = 14;

            worksheet.Range("A1:D3").Style.Alignment.Horizontal =
                XLAlignmentHorizontalValues.Center;

            //
            // Section Headers
            //
            foreach (var row in new[] { 5, 13, 21, 27 })
            {
                var range = worksheet.Range($"A{row}:C{row}");

                range.Style.Font.Bold = true;
                range.Style.Fill.BackgroundColor = XLColor.LightGray;
                range.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            }

            //
            // Labels
            //
            foreach (var row in new[]
            {
                7, 8, 9, 10, 11,
                15, 16, 17, 18, 19,
                23, 24, 25,
                29
            })
            {
                worksheet.Cell($"A{row}").Style.Font.Bold = true;
            }

            //
            // Value Alignment
            //
            foreach (var row in new[]
            {
        8, 9, 11,
        19,
        29
    })
            {
                worksheet.Cell($"C{row}").Style.Alignment.Horizontal =
                    XLAlignmentHorizontalValues.Right;
            }

            //
            // Date Formatting
            //
            worksheet.Cell("C7").Style.DateFormat.Format = ShortDateFormat;

            //
            // Currency Formatting
            //
            foreach (var row in new[]
            {
        15, 16, 17,
        23, 24, 25
    })
            {
                worksheet.Cell($"C{row}").Style.NumberFormat.Format =
                    CurrencyFormat;
            }

            //
            // Percent Formatting
            //
            worksheet.Cell("C18").Style.NumberFormat.Format =
                PercentFormat;

            //
            // Footer
            //
            worksheet.Range("A32:C32").Style.Font.FontSize = 9;
            worksheet.Range("A32:C32").Style.Font.FontColor = XLColor.Gray;

            //
            // Column Widths
            //
            worksheet.Column("A").Width = 34;
            worksheet.Column("B").Width = 4;
            worksheet.Column("C").Width = 24;
        }
        /// <summary>
        /// Writes the report footer for the Executive Summary worksheet.
        /// </summary>
        private static void WriteFooter(IXLWorksheet worksheet)
        {
            ArgumentNullException.ThrowIfNull(worksheet);

            worksheet.Cell("A32").Value =
                $"Reserve Workbook Generator v{CurrentWorkbookVersion}";

            worksheet.Cell("C32").Value =
                DateTime.Today;
        }
        /// <summary>
        /// Writes the Report Information section of the Executive Summary worksheet.
        /// </summary>
        private static void WriteReportInformation(
            IXLWorksheet worksheet,
            ExecutiveSummaryModel summary)
        {
            ArgumentNullException.ThrowIfNull(worksheet);
            ArgumentNullException.ThrowIfNull(summary);

            worksheet.Cell("A5").Value = "Report Information";

            worksheet.Cell("A7").Value = "Report Date";
            worksheet.Cell("C7").Value = summary.ReportDate;

            worksheet.Cell("A8").Value = "Study Year";
            worksheet.Cell("C8").Value = summary.StudyYear;

            worksheet.Cell("A9").Value = "Workbook Version";
            worksheet.Cell("C9").Value = summary.WorkbookVersion;

            worksheet.Cell("A10").Value = "Funding Method";
            worksheet.Cell("C10").Value = summary.FundingMethod;

            worksheet.Cell("A11").Value = "Components";
            worksheet.Cell("C11").Value = summary.ComponentCount;
        }
        /// <summary>
        /// Writes the report title section of the Executive Summary worksheet.
        /// </summary>
        private static void WriteTitle(IXLWorksheet worksheet)
        {
            ArgumentNullException.ThrowIfNull(worksheet);

            worksheet.Cell("A1").Value =
                "Grand Cove Condominium Association";

            worksheet.Cell("A2").Value =
                "Reserve Funding Workbook";

            worksheet.Cell("A3").Value =
                "Executive Summary";
        }

    }


}