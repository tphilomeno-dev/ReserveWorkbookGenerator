using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Engine;
using ReserveWorkbookGenerator.Excel;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Editor.Services;

public sealed class WorkbookGenerationService
{
    public string Generate(ReserveStudy study, string outputFolder)
    {
        var engine = new ReserveEngine(
            new ReserveScheduleBuilder(),
            new FfbCalculator(),
            new AllocationCalculator(),
            new AnnualContributionCalculator());

        var schedule = engine.Build(
            study.Components,
            study.Settings);

        var exporter = new ExcelWorkbookExporter();

        var outputFile = Path.Combine(
            outputFolder,
            $"{MakeSafeFileName(study.Study.AssociationName)} Reserve Workbook.xlsx");

        exporter.Export(outputFile, study, schedule);

        return outputFile;
    }
    private static string MakeSafeFileName(string fileName)
    {
        foreach (char c in Path.GetInvalidFileNameChars())
        {
            fileName = fileName.Replace(c, '_');
        }

        return fileName;
    }
}