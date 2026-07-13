using ClosedXML.Excel;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Exporters;

public class ExcelWorkbookExporter : IWorkbookExporter
{
    public void Export(
        string fileName,
        IEnumerable<ReserveScheduleRow> schedule)
    {
        var workbook = new XLWorkbook();

        var worksheet = workbook.Worksheets.Add("Reserve Schedule");
        worksheet.Cell(1, 1).Value = "Component";
        worksheet.Cell(1, 2).Value = "Replacement Cost";
        worksheet.Cell(1, 3).Value = "Useful Life";
        worksheet.Cell(1, 4).Value = "Remaining Life";
        worksheet.Cell(1, 5).Value = "FFB";

        int row = 2;

        foreach (var item in schedule)
        {
            worksheet.Cell(row, 1).Value = item.Component.Component;
            worksheet.Cell(row, 2).Value = item.Component.ReplacementCost;
            worksheet.Cell(row, 3).Value = item.Component.UsefulLife;
            worksheet.Cell(row, 4).Value = item.Component.RemainingLife;
            worksheet.Cell(row, 5).Value = item.FFB;

            row++;
        }

        workbook.SaveAs(fileName);
    }
}