using System.Text.Json;
using System.Text.Json.Serialization;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Exporters;

public sealed class JsonReserveStudyExporter
{
    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true
    };

    public JsonReserveStudyExporter()
    {
        _options.Converters.Add(new JsonStringEnumConverter());
    }

    public void Save(string fileName, ReserveStudy study)
    {
        var json = JsonSerializer.Serialize(study, _options);
        File.WriteAllText(fileName, json);
    }
}