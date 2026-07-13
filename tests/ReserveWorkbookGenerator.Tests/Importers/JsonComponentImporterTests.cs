using FluentAssertions;
using ReserveWorkbookGenerator.Importers;

namespace ReserveWorkbookGenerator.Tests.Importers;

public class JsonComponentImporterTests
{
    [Fact]
    public void Load_Should_Read_Components()
    {
        var json = """
        [
          {
            "Id":1,
            "Category":"Roofing",
            "Component":"Roof",
            "LastReplaced":2006,
            "UsefulLife":30,
            "RemainingLife":20,
            "ReplacementCost":600000
          }
        ]
        """;

        var file = Path.GetTempFileName();

        File.WriteAllText(file, json);

        var importer = new JsonComponentImporter();

        var components = importer.Load(file);

        components.Should().HaveCount(1);

        components[0].Component.Should().Be("Roof");
    }
}