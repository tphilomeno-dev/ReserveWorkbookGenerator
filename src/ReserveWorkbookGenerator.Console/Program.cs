using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Engine;
using ReserveWorkbookGenerator.Exporters;
using ReserveWorkbookGenerator.Importers;
using ReserveWorkbookGenerator.Models;

var importer = new JsonComponentImporter();

var components =
    importer.Load(@"Data\GrandCove.json");

var settings = new ReserveSettings
{
    BeginningReservePool = 1_250_000m,
    UnitCount = 24
};

var engine = new ReserveEngine(
    new ReserveScheduleBuilder(),
    new FfbCalculator(),
    new AllocationCalculator(),
    new AnnualContributionCalculator());

var schedule = engine.Build(
    components,
    settings);

var exporter = new ExcelWorkbookExporter();

var outputFile = Path.Combine(
    AppContext.BaseDirectory,
    "Grand Cove Reserve Workbook.xlsx");

exporter.Export(outputFile, schedule);

Console.WriteLine($"Workbook written to: {outputFile}");

foreach (var row in schedule)
{
    Console.WriteLine(
        $"{row.Component.Component,-30} " +
        $"FFB = {row.FFB:C0}  " +
        $"Weight = {row.FfbWeight:P2}  " +
        $"Allocation = {row.BeginningAllocation:C0}");
}