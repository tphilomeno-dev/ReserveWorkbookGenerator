using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Engine;
using ReserveWorkbookGenerator.Importers;

var importer = new JsonComponentImporter();

var components =
    importer.Load(@"Data\GrandCove.json");

var engine =
    new ReserveEngine(
        new FfbCalculator());

var schedule =
    engine.Build(components);

foreach (var row in schedule)
{
    Console.WriteLine(
        $"{row.Component.Component,-30}  " +
        $"FFB = {row.FFB:C0}");
}