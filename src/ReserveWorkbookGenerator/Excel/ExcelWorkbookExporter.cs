using ClosedXML.Excel;
using KofCWSC.ReserveWorkbookGenerator.Excel.Sheets;
using ReserveWorkbookGenerator.Excel.Sheets;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Excel;

public class ExcelWorkbookExporter  
{

    public void Export(
    string fileName,
    ReserveStudy study,
    IEnumerable<ReserveScheduleRow> schedule)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fileName);
        ArgumentNullException.ThrowIfNull(schedule);

        using var workbook = new XLWorkbook();

        ReserveComponentInventorySheet.Build(workbook, study.Components);

        ExecutiveSummarySheet.Build(workbook, schedule);

        ReserveScheduleSheet.Build(workbook, schedule);

        FundingScheduleSheet.Build(workbook, schedule);

        workbook.SaveAs(fileName);
    }
}