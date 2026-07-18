using ReserveWorkbookGenerator.Calculators;
using ReserveWorkbookGenerator.Engine;
using ReserveWorkbookGenerator.Excel;
using ReserveWorkbookGenerator.Importers;
using ReserveWorkbookGenerator.Models;
using System.Diagnostics;

var importer = new JsonReserveStudyImporter();

var study =
    importer.Load(@"Data\GrandCove-Current.json");



var engine = new ReserveEngine(
    new ReserveScheduleBuilder(),
    new FfbCalculator(),
    new AllocationCalculator(),
    new AnnualContributionCalculator());

var schedule = engine.Build(
    study.Components,
    study.Settings);

Console.WriteLine();
Console.WriteLine("Reserve Schedule");

foreach (var row in schedule)
{
    Console.WriteLine(
        $"{row.Component.Component,-30}" +
        $" FFB={row.FFB,12:C0}" +
        $" Begin={row.BeginningAllocation,12:C0}" +
        $" Remaining={row.RemainingRequired,12:C0}" +
        $" Annual={row.AnnualContribution,12:C0}" +
        $" Monthly={row.MonthlyContribution,10:C0}" +
        $" CPU={row.MonthlyCpu,8:C2}");
}

var exporter = new ExcelWorkbookExporter();

var outputFile = Path.Combine(
    AppContext.BaseDirectory,
    "Grand Cove Reserve Workbook.xlsx");

exporter.Export(outputFile, schedule);

Console.WriteLine($"Workbook written to: {outputFile}");

Process.Start(new ProcessStartInfo
{
    FileName = outputFile,
    UseShellExecute = true
});

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