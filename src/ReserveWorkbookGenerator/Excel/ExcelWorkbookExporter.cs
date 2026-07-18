using ClosedXML.Excel;
using ReserveWorkbookGenerator.Models;
using ReserveWorkbookGenerator.Excel.Sheets;

namespace ReserveWorkbookGenerator.Excel;

public class ExcelWorkbookExporter  
{
    
    public void Export(
        string fileName,
        IEnumerable<ReserveScheduleRow> schedule)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fileName);
        ArgumentNullException.ThrowIfNull(schedule);

        using var workbook = new XLWorkbook();

        ExecutiveSummarySheet.Build(workbook, schedule);

        ReserveScheduleSheet.Build(workbook, schedule);

        FundingScheduleSheet.Build(workbook, schedule);

        workbook.SaveAs(fileName);
    }
}