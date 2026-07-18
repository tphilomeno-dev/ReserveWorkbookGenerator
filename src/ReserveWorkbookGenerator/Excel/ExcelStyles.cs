using ClosedXML.Excel;

namespace ReserveWorkbookGenerator.Excel;

/// <summary>
/// Shared worksheet styling helpers.
/// </summary>
internal static class ExcelStyles
{
    public static void ApplySectionHeader(IXLRange range)
    {
        ArgumentNullException.ThrowIfNull(range);

        range.Style.Font.Bold = true;
        range.Style.Fill.BackgroundColor = XLColor.LightGray;
        range.Style.Alignment.Horizontal =
            XLAlignmentHorizontalValues.Center;
        range.Style.Alignment.Vertical =
            XLAlignmentVerticalValues.Center;
    }

    public static void ApplyTotalsRow(IXLRange range)
    {
        ArgumentNullException.ThrowIfNull(range);

        range.Style.Font.Bold = true;
        range.Style.Fill.BackgroundColor =
            XLColor.LightSteelBlue;

        range.Style.Border.TopBorder =
            XLBorderStyleValues.Thick;
    }

    public static void ApplyWorksheetTitle(IXLCell cell, int fontSize)
    {
        ArgumentNullException.ThrowIfNull(cell);

        cell.Style.Font.Bold = true;
        cell.Style.Font.FontSize = fontSize;
    }

    public static void ApplyFooter(IXLRange range)
    {
        ArgumentNullException.ThrowIfNull(range);

        range.Style.Font.FontSize = 9;
        range.Style.Font.FontColor = XLColor.Gray;
    }
}