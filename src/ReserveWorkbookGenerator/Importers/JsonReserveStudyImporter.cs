using System.Text.Json;
using System.Text.Json.Serialization;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Importers;

public class JsonReserveStudyImporter
{
    public ReserveStudy Load(string fileName)
    {
        if (!File.Exists(fileName))
            throw new FileNotFoundException(fileName);

        var json = File.ReadAllText(fileName);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        options.Converters.Add(new JsonStringEnumConverter());

        return JsonSerializer.Deserialize<ReserveStudy>(
            json,
            options) ?? new ReserveStudy();
    }
}