using DocumentFormat.OpenXml.Bibliography;
using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Engine;
using ReserveWorkbookGenerator.Excel;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Editor.Services;

public sealed class WorkbookGenerator
{
    public string Generate(ReserveStudy study, string outputFile)
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

        exporter.Export(outputFile, study, schedule);

        return outputFile;
    }
}