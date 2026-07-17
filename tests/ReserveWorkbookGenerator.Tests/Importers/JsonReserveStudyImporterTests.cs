using FluentAssertions;
using ReserveWorkbookGenerator.Importers;

namespace ReserveWorkbookGenerator.Tests.Importers;

public class JsonReserveStudyImporterTests
{
    [Fact]
    public void Load_Should_Read_Components()
    {
        var json = """
        {
          "study": {
            "associationName": "Test Condo",
            "propertyDescription": "Unit Test",
            "studyDate": "2026-07-17",
            "preparedBy": "Unit Test",
            "version": "1.0",
            "notes": ""
          },
          "settings": {
            "currentYear": 2026,
            "unitCount": 24,
            "beginningReservePool": 1250000,
            "annualReserveBudget": 150000,
            "annualInterest": 0.03,
            "inflationRate": 0.03,
            "allocationMethod": "FullyFundedBalance"
          },
          "components": [
            {
              "id": 1,
              "category": "Roofing",
              "component": "Roof",
              "lastReplaced": 2006,
              "usefulLife": 30,
              "remainingLife": 20,
              "replacementCost": 600000
            }
          ]
        }
        """;

        var file = Path.GetTempFileName();

        File.WriteAllText(file, json);

        var importer = new JsonReserveStudyImporter();

        var study = importer.Load(file);

        study.Should().NotBeNull();

        study.Study.AssociationName.Should().Be("Test Condo");

        study.Settings.CurrentYear.Should().Be(2026);
        study.Settings.UnitCount.Should().Be(24);
        study.Settings.BeginningReservePool.Should().Be(1_250_000m);

        study.Components.Should().HaveCount(1);
        study.Components[0].Component.Should().Be("Roof");
    }
}