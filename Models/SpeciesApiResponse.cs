namespace MonkeyMon_Blazor.Models;

public class SpeciesApiResponse
{
    public string Name { get; set; } = String.Empty;

    public ICollection<string> Locations { get; set; } = [];

    public IDictionary<string, string> Taxonomy { get; set; } = new Dictionary<string, string>();

    public IDictionary<string, string> Characteristics { get; set; } = new Dictionary<string, string>();
}