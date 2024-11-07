using System.Text.Json.Serialization;

namespace MonkeyMon_Blazor.Models;

/// <summary>
/// The base class for all resource lists
/// </summary>
public abstract class PokeApiResourceList<T> where T : PokeApiResourceBase
{
    /// <summary>
    /// The total number of resources available from this API
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }

    /// <summary>
    /// The URL for the next page in the list.
    /// </summary>
    [JsonPropertyName("next")]
    public string? Next { get; set; }

    /// <summary>
    /// The URL for the previous page in the list.
    /// </summary>
    [JsonPropertyName("previous")]
    public string? Previous { get; set; }
}

/// <summary>
/// The paging object for un-named resources
/// </summary>
/// <typeparam name="T">The type of the paged resource</typeparam>
public class PokeApiApiResourceList<T> : PokeApiResourceList<T> where T : PokeApiApiResource
{
    /// <summary>
    /// A list of un-named API resources.
    /// </summary>
    [JsonPropertyName("results")]
    public List<PokeApiApiResource<T>> Results { get; set; }
}

/// <summary>
/// The paging object for named resources
/// </summary>
/// <typeparam name="T">The type of the paged resource</typeparam>
public class PokeApiNamedApiResourceList<T> : PokeApiResourceList<T> where T : PokeApiNamedApiResource
{
    /// <summary>
    /// A list of named API resources.
    /// </summary>
    [JsonPropertyName("results")]
    public List<PokeApiNamedApiResource<T>> Results { get; set; }
}