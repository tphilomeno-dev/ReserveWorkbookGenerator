using ClosedXML.Excel;
using ReserveWorkbookGenerator.Analysis;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Exporters;

public class ExcelWorkbookExporter : IWorkbookExporter
{
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

        //
        // Calculate summary values
        //

        var componentCount =
            schedule.Count();

        var totalReplacementCost =
            schedule.Sum(x => x.Component.ReplacementCost);

        var totalFfb =
            schedule.Sum(x => x.FFB);

        var totalAllocation =
            schedule.Sum(x => x.BeginningAllocation);

        var totalAnnualContribution =
            schedule.Sum(x => x.AnnualContribution);

        var percentFunded =
            totalFfb == 0m
                ? 0m
                : totalAllocation / totalFfb;

        var fundingAnalyzer = new FundingLevelAnalyzer();

        var fundingLevel =
            fundingAnalyzer.Calculate(percentFunded);

        //
        // Report Title
        //

        worksheet.Cell("A1").Value = "Reserve Analysis Report";
        worksheet.Cell("A2").Value = "Executive Summary";

        //
        // Report Information
        //

        worksheet.Cell("A4").Value = "Report Information";

        worksheet.Cell("A6").Value = "Generated";
        worksheet.Cell("B6").Value = DateTime.Now;

        worksheet.Cell("A7").Value = "Components";
        worksheet.Cell("B7").Value = componentCount;

        //
        // Key Metrics
        //
        worksheet.Cell("A9").Value = "Key Metrics";

        worksheet.Cell("A11").Value = "Total Replacement Cost";
        worksheet.Cell("B11").Value = totalReplacementCost;

        worksheet.Cell("A12").Value = "Total Fully Funded Balance";
        worksheet.Cell("B12").Value = totalFfb;

        worksheet.Cell("A13").Value = "Beginning Allocation";
        worksheet.Cell("B13").Value = totalAllocation;

        worksheet.Cell("A14").Value = "Annual Contribution";
        worksheet.Cell("B14").Value = totalAnnualContribution;

        //
        // Funding Summary
        //

        worksheet.Cell("A16").Value = "Funding Summary";

        worksheet.Cell("A18").Value = "Beginning Allocation";
        worksheet.Cell("B18").Value = totalAllocation;

        worksheet.Cell("A19").Value = "Fully Funded Balance";
        worksheet.Cell("B19").Value = totalFfb;

        worksheet.Cell("A20").Value = "Percent Funded";
        worksheet.Cell("B20").Value = percentFunded;

        worksheet.Cell("A21").Value = "Funding Level";
        worksheet.Cell("B21").Value = fundingLevel.ToString();

        //
        // Formatting
        //

        worksheet.Cell("A1").Style.Font.Bold = true;
        worksheet.Cell("A1").Style.Font.FontSize = 20;

        worksheet.Cell("A2").Style.Font.Bold = true;
        worksheet.Cell("A2").Style.Font.FontSize = 14;

        worksheet.Range("A4:B4").Style.Font.Bold = true;
        worksheet.Range("A9:B9").Style.Font.Bold = true;
        worksheet.Range("A16:B16").Style.Font.Bold = true;

        worksheet.Range("A6:A20").Style.Font.Bold = true;

        worksheet.Range("A18:A21").Style.Font.Bold = true;

        worksheet.Cell("B6").Style.DateFormat.Format =
            "MMMM d, yyyy";

        worksheet.Cell("B11").Style.NumberFormat.Format =
            "$#,##0";

        worksheet.Cell("B12").Style.NumberFormat.Format =
            "$#,##0";

        worksheet.Cell("B13").Style.NumberFormat.Format =
            "$#,##0";

        worksheet.Cell("B14").Style.NumberFormat.Format =
            "$#,##0";

        worksheet.Cell("B18").Style.NumberFormat.Format =
            "$#,##0";

        worksheet.Cell("B19").Style.NumberFormat.Format =
            "$#,##0";

        worksheet.Cell("B20").Style.NumberFormat.Format =
            "0.0%";

        worksheet.Columns().AdjustToContents();

        // merge cells for the report title
        worksheet.Range("A1:B1").Merge();
        worksheet.Range("A2:B2").Merge();

        worksheet.Cell("A1").Style.Alignment.Horizontal =
            XLAlignmentHorizontalValues.Center;

        worksheet.Cell("A2").Style.Alignment.Horizontal =
            XLAlignmentHorizontalValues.Center;

        // color the report title
        worksheet.Range("A4:B4").Style.Fill.BackgroundColor =
    XLColor.LightGray;

        worksheet.Range("A9:B9").Style.Fill.BackgroundColor =
            XLColor.LightGray;

        worksheet.Range("A16:B16").Style.Fill.BackgroundColor =
            XLColor.LightGray;
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

            row ++;
        }
        // Formatting
        worksheet.Column("D").Style.NumberFormat.Format = "0.0%";
    }
}