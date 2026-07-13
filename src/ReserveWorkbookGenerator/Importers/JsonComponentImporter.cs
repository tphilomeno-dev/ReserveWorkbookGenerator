using System.Text.Json;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Importers;

public class JsonComponentImporter
{
    public List<ReserveComponent> Load(string fileName)
    {
        if (!File.Exists(fileName))
            throw new FileNotFoundException(fileName);

        var json = File.ReadAllText(fileName);

        var components =
            JsonSerializer.Deserialize<List<ReserveComponent>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

        return components ?? new List<ReserveComponent>();
    }
}