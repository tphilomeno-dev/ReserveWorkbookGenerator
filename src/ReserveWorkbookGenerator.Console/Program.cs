using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Engine;
using ReserveWorkbookGenerator.Exporters;
using ReserveWorkbookGenerator.Importers;

var importer = new JsonComponentImporter();

var components =
    importer.Load(@"Data\GrandCove.json");

var engine = new ReserveEngine(
    new ReserveScheduleBuilder(),
    new FfbCalculator());
var schedule =
    engine.Build(components);

var exporter = new ExcelWorkbookExporter();
var outputFile = Path.Combine(
    AppContext.BaseDirectory,
    "Grand Cove Reserve Workbook.xlsx");
exporter.Export(outputFile, schedule);

Console.WriteLine(outputFile);
//exporter.Export(
//    "Grand Cove Reserve Workbook.xlsx",
//    schedule);

Console.WriteLine("Workbook written successfully.");

foreach (var row in schedule)
{
    Console.WriteLine(
        $"{row.Component.Component,-30}  " +
        $"FFB = {row.FFB:C0}");
}