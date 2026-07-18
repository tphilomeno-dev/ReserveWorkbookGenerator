using ClosedXML.Excel;
using ReserveWorkbookGenerator.Analysis;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Exporters;

public class ExcelWorkbookExporter : IWorkbookExporter
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
    public void Export(
        string fileName,
        IEnumerable<ReserveScheduleRow> schedule)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fileName);
        ArgumentNullException.ThrowIfNull(schedule);

        var workbook = new XLWorkbook();

        BuildExecutiveSummary(workbook, schedule);

        BuildReserveSchedule(workbook, schedule);

        BuildFundingSchedule(workbook, schedule);

        SaveWorkbook(workbook, fileName);
    }

    /// <summary>
    /// Builds the Executive Summary worksheet.
    /// </summary>
    private static void BuildExecutiveSummary(
    XLWorkbook workbook,
    IEnumerable<ReserveScheduleRow> schedule)
    {
        var worksheet = workbook.Worksheets.Add("01 Executive Summary");

        var summary = BuildExecutiveSummaryModel(schedule);

        WriteTitle(worksheet);

        WriteReportInformation(worksheet, summary);

        WriteCurrentReservePosition(worksheet, summary);

        WriteFundingRecommendation(worksheet, summary);

        WriteFundingAssessment(worksheet, summary);

        FormatExecutiveSummary(worksheet);

        WriteFooter(worksheet);

        worksheet.Columns().AdjustToContents();
    }

    /// <summary>
    /// Builds the Reserve Schedule worksheet.
    /// </summary>
    private static void BuildReserveSchedule(
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

    /// <summary>
    /// Saves the workbook.
    /// </summary>
    private static void SaveWorkbook(
        XLWorkbook workbook,
        string fileName)
    {
        workbook.SaveAs(fileName);
    }

    private static void BuildFundingSchedule(
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
    private sealed class ExecutiveSummaryModel
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
    private static ExecutiveSummaryModel BuildExecutiveSummaryModel(
    IEnumerable<ReserveScheduleRow> schedule)
    {
        var rows = schedule.ToList();

        var totalReplacementCost =
            rows.Sum(x => x.Component.ReplacementCost);

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

            StudyYear = DateTime.Today.Year,

            WorkbookVersion = "1.3.0",

            FundingMethod = "Fully Funded Balance (Pooled)",

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

        worksheet.Cell("A18").Value = "Percent Funded";
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
            "Reserve Workbook Generator v1.3.0";

        worksheet.Cell("C32").Value =
            DateTime.Today;
    }
}