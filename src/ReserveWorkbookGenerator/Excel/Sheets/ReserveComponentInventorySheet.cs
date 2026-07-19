using ClosedXML.Excel;
using ReserveWorkbookGenerator.Excel;
using ReserveWorkbookGenerator.Models;

namespace KofCWSC.ReserveWorkbookGenerator.Excel.Sheets;

public static class ReserveComponentInventorySheet
{
    private const string WorksheetName = "01 Reserve Component Inventory";
    private const int HeaderRow = 1;
    private const int FirstDataRow = 2;

    public static void Build(
        XLWorkbook workbook,
        IEnumerable<ReserveComponent> components)
    {
        var worksheet = workbook.Worksheets.Add(WorksheetName);

        var sortedComponents = components
            .OrderBy(c => c.Id)
            .ToList();

        WriteHeaders(worksheet);

        WriteDetailRows(worksheet, sortedComponents);

        FormatWorksheet(worksheet);
    }

    private static void WriteHeaders(IXLWorksheet worksheet)
    {
        worksheet.Cell(HeaderRow, 1).Value = "ID";
        worksheet.Cell(HeaderRow, 2).Value = "Type";
        worksheet.Cell(HeaderRow, 3).Value = "Category";
        worksheet.Cell(HeaderRow, 4).Value = "Name";
        worksheet.Cell(HeaderRow, 5).Value = "Last Replaced";
        worksheet.Cell(HeaderRow, 6).Value = "Useful Life";
        worksheet.Cell(HeaderRow, 7).Value = "Remaining Life";
        worksheet.Cell(HeaderRow, 8).Value = "Replacement Cost";
        worksheet.Cell(HeaderRow, 9).Value = "Comments";

        var headerRange = worksheet.Range(HeaderRow, 1, HeaderRow, 9);

        ExcelStyles.ApplySectionHeader(headerRange);
    }

    private static void WriteDetailRows(
    IXLWorksheet worksheet,
    IReadOnlyList<ReserveComponent> components)
    {
        var row = FirstDataRow;

        foreach (var component in components)
        {
            worksheet.Cell(row, 1).Value = component.Id;
            worksheet.Cell(row, 2).Value =
                component.Type == ReserveType.Sirs
                    ? "SIRS"
                    : "Non-SIRS";
            worksheet.Cell(row, 3).Value = component.Category;
            worksheet.Cell(row, 4).Value = component.Name;
            worksheet.Cell(row, 5).Value = component.LastReplaced;
            worksheet.Cell(row, 6).Value = component.UsefulLife;
            worksheet.Cell(row, 7).Value = component.RemainingLife;
            worksheet.Cell(row, 8).Value = component.ReplacementCost;
            worksheet.Cell(row, 9).Value = component.Comments;

            row++;
        }
    }

    private static void FormatWorksheet(IXLWorksheet worksheet)
    {
        // Freeze the header row
        worksheet.SheetView.FreezeRows(1);

        // Enable filtering
        //worksheet.RangeUsed()?.SetAutoFilter();

        // Alignment
        worksheet.Column(1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // ID
        worksheet.Column(2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // Type
        worksheet.Column(5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // Last Replaced
        worksheet.Column(6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // Useful Life
        worksheet.Column(7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // Remaining Life

        // Currency
        worksheet.Column(8).Style.NumberFormat.Format = "$#,##0";

        // Wrap comments
        worksheet.Column(9).Style.Alignment.WrapText = true;
        worksheet.Column(9).Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;

        // Auto-size all columns
        worksheet.Columns().AdjustToContents();

        // Give Comments a little extra room
        if (worksheet.Column(9).Width < 40)
            worksheet.Column(9).Width = 40;

        var table = worksheet.RangeUsed().CreateTable();
        table.Theme = XLTableTheme.TableStyleMedium2;
    }
}