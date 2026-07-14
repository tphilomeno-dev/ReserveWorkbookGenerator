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

var projectionSettings = new ProjectionSettings
{
    NumberOfYears = 5,
    InterestRate = 0.03m,
    InflationRate = 0.00m
};

var firstYear = new ReserveProjectionYear
{
    Year = 2026,
    BeginningPool = 1_250_000m,
    AnnualContributions = 150_000m,
    InterestEarned = 20_000m,
    ReserveExpenditures = 75_000m
};

var projectionEngine = new ProjectionEngine();

var projection = projectionEngine.ProjectYears(
    projectionSettings,
    firstYear);

Console.WriteLine();
Console.WriteLine("Reserve Projection");
Console.WriteLine("------------------");

foreach (var year in projection)
{
    Console.WriteLine(
        $"{year.Year}  " +
        $"Begin: {year.BeginningPool,12:C0}  " +
        $"End: {year.EndingPool,12:C0}");
}