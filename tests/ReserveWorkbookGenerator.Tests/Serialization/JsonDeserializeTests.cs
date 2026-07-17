using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using ReserveWorkbookGenerator.Models;

namespace ReserveWorkbookGenerator.Tests.Serialization;

public class JsonDeserializeTests
{


    [Fact]
    public void Json_Should_Deserialize_AllocationMethod()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new JsonStringEnumConverter());

        var result = JsonSerializer.Deserialize<AllocationMethod>(
            "\"FullyFundedBalance\"",
            options);

        result.Should().Be(AllocationMethod.FullyFundedBalance);
    }
}