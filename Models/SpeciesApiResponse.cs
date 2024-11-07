using System.Text.Json.Serialization;

namespace MonkeyMon_Blazor.Models;

public class SpeciesApiResponse
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = String.Empty;

    [JsonPropertyName("locations")]
    public ICollection<string> Locations { get; set; } = [];

    [JsonPropertyName("taxonomy")]
    public IDictionary<string, string> Taxonomy { get; set; } = new Dictionary<string, string>();

    [JsonPropertyName("characteristics")]
    public IDictionary<string, string> Characteristics { get; set; } = new Dictionary<string, string>();
}