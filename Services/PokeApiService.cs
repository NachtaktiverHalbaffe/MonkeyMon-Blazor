using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;
using MonkeyMon_Blazor.Models;

namespace MonkeyMon_Blazor.Services;

public class PokeApiService(HttpClient client)
{
    /// <summary>
    /// Send a request to the api and serialize the response into the specified type
    /// </summary>
    /// <typeparam name="T">The type of resource</typeparam>
    /// <param name="apiParam">The name or id of the resource</param>
    /// <param name="cancellationToken">Cancellation token for the request; not utilized if data has been cached</param>
    /// <exception cref="HttpRequestException">Something went wrong with your request</exception>
    /// <returns>An instance of the specified type with data from the request</returns>
    private async Task<T> GetResourcesWithParamsAsync<T>(string apiParam, CancellationToken cancellationToken)
        where T : PokeApiResourceBase
    {
        // check for case sensitive API endpoint
        bool isApiEndpointCaseSensitive = IsApiEndpointCaseSensitive<T>();
        string sanitizedApiParam = isApiEndpointCaseSensitive ? apiParam : apiParam.ToLowerInvariant();
        string apiEndpoint = GetApiEndpointString<T>();

        return await GetAsync<T>($"{apiEndpoint}/{sanitizedApiParam}/", cancellationToken);
    }

    /// <summary>
    /// Gets a resource from a navigation url; resource is retrieved from cache if possible
    /// </summary>
    /// <typeparam name="T">The type of resource</typeparam>
    /// <param name="url">Navigation url</param>
    /// <param name="cancellationToken">Cancellation token for the request; not utilized if data has been cached</param>
    /// <exception cref="NotSupportedException">Navigation url doesn't contain the resource id</exception>
    /// <returns>The object of the resource</returns>
    private async Task<T> GetResourceByUrlAsync<T>(string url, CancellationToken cancellationToken)
        where T : PokeApiResourceBase
    {
        // need to parse out the id in order to check if it's cached.
        // navigation urls always use the id of the resource
        string trimmedUrl = url.TrimEnd('/');
        string resourceId = trimmedUrl.Substring(trimmedUrl.LastIndexOf('/') + 1);

        if (!int.TryParse(resourceId, out int id))
        {
            // not sure what to do here...
            throw new NotSupportedException($"Navigation url '{url}' is in an unexpected format");
        }

        T resource = await GetResourcesWithParamsAsync<T>(resourceId, cancellationToken);

        return resource;
    }

    /// <summary>
    /// Gets a resource by id; resource is retrieved from cache if possible
    /// </summary>
    /// <typeparam name="T">The type of resource</typeparam>
    /// <param name="id">Id of resource</param>
    /// <returns>The object of the resource</returns>
    public async Task<T> GetResourceAsync<T>(int id) where T : PokeApiResourceBase
    {
        return await GetResourceAsync<T>(id, CancellationToken.None);
    }

    /// <summary>
    /// Gets a resource by id; resource is retrieved from cache if possible
    /// </summary>
    /// <typeparam name="T">The type of resource</typeparam>
    /// <param name="id">Id of resource</param>
    /// <param name="cancellationToken">Cancellation token for the request; not utilized if data has been cached</param>
    /// <returns>The object of the resource</returns>
    public async Task<T> GetResourceAsync<T>(int id, CancellationToken cancellationToken)
        where T : PokeApiResourceBase
    {
        T resource = await GetResourcesWithParamsAsync<T>(id.ToString(), cancellationToken);
        return resource;
    }

    /// <summary>
    /// Gets a resource by name; resource is retrieved from cache if possible. This lookup
    /// is case insensitive.
    /// </summary>
    /// <typeparam name="T">The type of resource</typeparam>
    /// <param name="name">Name of resource</param>
    /// <returns>The object of the resource</returns>
    public async Task<T> GetResourceAsync<T>(string name)
        where T : PokeApiNamedApiResource
    {
        return await GetResourceAsync<T>(name, CancellationToken.None);
    }

    /// <summary>
    /// Gets a resource by name; resource is retrieved from cache if possible. This lookup
    /// is case insensitive.
    /// </summary>
    /// <typeparam name="T">The type of resource</typeparam>
    /// <param name="name">Name of resource</param>
    /// <param name="cancellationToken">Cancellation token for the request; not utilized if data has been cached</param>
    /// <returns>The object of the resource</returns>
    public async Task<T> GetResourceAsync<T>(string name, CancellationToken cancellationToken)
        where T : PokeApiNamedApiResource
    {
        string sanitizedName = name
            .Replace(" ", "-") // no resource can have a space in the name; API uses -'s in their place
            .Replace("'", "") // looking at you, Farfetch'd
            .Replace(".", ""); // looking at you, Mime Jr. and Mr. Mime

        // Nidoran is interesting as the API wants 'nidoran-f' or 'nidoran-m'
        T resource = await GetResourcesWithParamsAsync<T>(sanitizedName, cancellationToken);

        return resource;
    }

    /// <summary>
    /// Resolves all navigation properties in a collection
    /// </summary>
    /// <typeparam name="T">Navigation type</typeparam>
    /// <param name="collection">The collection of navigation objects</param>
    /// <returns>A list of resolved objects</returns>
    public async Task<List<T>> GetResourceAsync<T>(IEnumerable<PokeApiUrlNavigation<T>> collection)
        where T : PokeApiResourceBase
    {
        return await GetResourceAsync<T>(collection, CancellationToken.None);
    }

    /// <summary>
    /// Resolves all navigation properties in a collection
    /// </summary>
    /// <typeparam name="T">Navigation type</typeparam>
    /// <param name="collection">The collection of navigation objects</param>
    /// <param name="cancellationToken">Cancellation token for the request; not utilized if data has been cached</param>
    /// <returns>A list of resolved objects</returns>
    public async Task<List<T>> GetResourceAsync<T>(IEnumerable<PokeApiUrlNavigation<T>> collection,
        CancellationToken cancellationToken)
        where T : PokeApiResourceBase
    {
        return (await Task.WhenAll(collection.Select(m => GetResourceAsync(m, cancellationToken)))).ToList();
    }

    /// <summary>
    /// Resolves a single navigation property
    /// </summary>
    /// <typeparam name="T">Navigation type</typeparam>
    /// <param name="urlResource">The single navigation object to resolve</param>
    /// <returns>A resolved object</returns>
    public async Task<T> GetResourceAsync<T>(PokeApiUrlNavigation<T> urlResource)
        where T : PokeApiResourceBase
    {
        return await GetResourceByUrlAsync<T>(urlResource.Url, CancellationToken.None);
    }

    /// <summary>
    /// Resolves a single navigation property
    /// </summary>
    /// <typeparam name="T">Navigation type</typeparam>
    /// <param name="urlResource">The single navigation object to resolve</param>
    /// <param name="cancellationToken">Cancellation token for the request; not utilized if data has been cached</param>
    /// <returns>A resolved object</returns>
    public async Task<T> GetResourceAsync<T>(PokeApiUrlNavigation<T> urlResource, CancellationToken cancellationToken)
        where T : PokeApiResourceBase
    {
        return await GetResourceByUrlAsync<T>(urlResource.Url, cancellationToken);
    }


    /// <summary>
    /// Gets a single page of named resource data
    /// </summary>
    /// <typeparam name="T">The type of resource</typeparam>
    /// <param name="cancellationToken">Cancellation token for the request; not utilized if data has been cached</param>
    /// <returns>The paged resource object</returns>
    public Task<PokeApiNamedApiResourceList<T>> GetNamedResourcePageAsync<T>(
        CancellationToken cancellationToken = default)
        where T : PokeApiNamedApiResource
    {
        string url = GetApiEndpointString<T>();
        return InternalGetNamedResourcePageAsync<T>(AddPaginationParamsToUrl(url), cancellationToken);
    }

    /// <summary>
    /// Gets the specified page of named resource data
    /// </summary>
    /// <typeparam name="T">The type of resource</typeparam>
    /// <param name="limit">The number of resources in a list page</param>
    /// <param name="offset">Page offset</param>
    /// <param name="cancellationToken">Cancellation token for the request; not utilized if data has been cached</param>
    /// <returns>The paged resource object</returns>
    public Task<PokeApiNamedApiResourceList<T>> GetNamedResourcePageAsync<T>(int limit, int offset,
        CancellationToken cancellationToken = default)
        where T : PokeApiNamedApiResource
    {
        string url = GetApiEndpointString<T>();
        return InternalGetNamedResourcePageAsync<T>(AddPaginationParamsToUrl(url, limit, offset), cancellationToken);
    }

    /// <summary>
    /// Gets all the named resources
    /// </summary>
    /// <typeparam name="T">The type of resource</typeparam>
    /// <param name="cancellationToken">Cancellation token for the request; not utilized if data has been cached</param>
    /// <returns>An async enumeration of the requested resources</returns>
    public async IAsyncEnumerable<PokeApiNamedApiResource<T>> GetAllNamedResourcesAsync<T>(
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
        where T : PokeApiNamedApiResource
    {
        string url = GetApiEndpointString<T>();
        bool isLastPage;

        do
        {
            var page = await GetAsync<PokeApiNamedApiResourceList<T>>(url, cancellationToken);
            foreach (var resource in page?.Results ?? Enumerable.Empty<PokeApiNamedApiResource<T>>())
            {
                if (cancellationToken.IsCancellationRequested) break;
                yield return resource;
            }

            isLastPage = page?.Next is null;
            if (!isLastPage)
            {
                url = page!.Next!;
            }
        } while (!cancellationToken.IsCancellationRequested && !isLastPage);
    }

    private async Task<PokeApiNamedApiResourceList<T>> InternalGetNamedResourcePageAsync<T>(string url,
        CancellationToken cancellationToken)
        where T : PokeApiNamedApiResource
    {
        var resources = await GetAsync<PokeApiNamedApiResourceList<T>>(url, cancellationToken);

        return resources;
    }

    /// <summary>
    /// Gets a single page of unnamed resource data
    /// </summary>
    /// <typeparam name="T">The type of resource</typeparam>
    /// <param name="cancellationToken">Cancellation token for the request; not utilized if data has been cached</param>
    /// <returns>The paged resource object</returns>
    public Task<PokeApiApiResourceList<T>> GetApiResourcePageAsync<T>(CancellationToken cancellationToken = default)
        where T : PokeApiApiResource
    {
        string url = GetApiEndpointString<T>();
        return InternalGetApiResourcePageAsync<T>(AddPaginationParamsToUrl(url), cancellationToken);
    }

    /// <summary>
    /// Gets the specified page of unnamed resource data
    /// </summary>
    /// <typeparam name="T">The type of resource</typeparam>
    /// <param name="limit">The number of resources in a list page</param>
    /// <param name="offset">Page offset</param>
    /// <param name="cancellationToken">Cancellation token for the request; not utilized if data has been cached</param>
    /// <returns>The paged resource object</returns>
    public Task<PokeApiApiResourceList<T>> GetApiResourcePageAsync<T>(int limit, int offset,
        CancellationToken cancellationToken = default)
        where T : PokeApiApiResource
    {
        string url = GetApiEndpointString<T>();
        return InternalGetApiResourcePageAsync<T>(AddPaginationParamsToUrl(url, limit, offset), cancellationToken);
    }

    /// <summary>
    /// Gets all the unnamed resources
    /// </summary>
    /// <typeparam name="T">The type of resource</typeparam>
    /// <param name="cancellationToken">Cancellation token for the request; not utilized if data has been cached</param>
    /// <returns>An async enumeration of the requested resources</returns>
    public async IAsyncEnumerable<PokeApiApiResource<T>> GetAllApiResourcesAsync<T>(
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
        where T : PokeApiApiResource
    {
        string url = GetApiEndpointString<T>();
        bool isLastPage;

        do
        {
            var page = await GetAsync<PokeApiApiResourceList<T>>(url, cancellationToken);
            foreach (var resource in page?.Results ?? Enumerable.Empty<PokeApiApiResource<T>>())
            {
                if (cancellationToken.IsCancellationRequested) break;
                yield return resource;
            }

            isLastPage = page?.Next is null;
            if (!isLastPage)
            {
                url = page!.Next!;
            }
        } while (!cancellationToken.IsCancellationRequested && !isLastPage);
    }

    private async Task<PokeApiApiResourceList<T>> InternalGetApiResourcePageAsync<T>(string url,
        CancellationToken cancellationToken)
        where T : PokeApiApiResource
    {
        var resources = await GetAsync<PokeApiApiResourceList<T>>(url, cancellationToken);


        return resources;
    }

    /// <summary>
    /// Handles all outbound API requests to the PokeAPI server and deserializes the response
    /// </summary>
    private async Task<T?> GetAsync<T>(string url, CancellationToken cancellationToken)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        using var response =
            await client.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken);

        response.EnsureSuccessStatusCode();
        var str =await response.Content.ReadAsStringAsync();
        return DeserializeStream<T>(await response.Content.ReadAsStreamAsync());
    }

    /// <summary>
    /// Handles deserialization of a given stream to a given type
    /// </summary>
    private T? DeserializeStream<T>(System.IO.Stream stream)
    {
        using var sr = new System.IO.StreamReader(stream);
        return JsonSerializer.Deserialize<T>(stream,
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower });
    }

    private static string AddPaginationParamsToUrl(string uri, int? limit = null, int? offset = null)
    {
        var queryParameters = new Dictionary<string, string>();

        // TODO consider to always set the limit parameter when not present to the default "20"
        // in order to have a single cached resource list for requests with explicit or implicit default limit
        if (limit.HasValue)
        {
            queryParameters.Add(nameof(limit), limit.Value.ToString());
        }

        if (offset.HasValue)
        {
            queryParameters.Add(nameof(offset), offset.Value.ToString());
        }

        return QueryHelpers.AddQueryString(uri, queryParameters);
    }

    private static string GetApiEndpointString<T>()
    {
        PropertyInfo propertyInfo = typeof(T).GetProperty("ApiEndpoint", BindingFlags.Static | BindingFlags.NonPublic);
        return propertyInfo.GetValue(null).ToString();
    }

    private static bool IsApiEndpointCaseSensitive<T>()
    {
        PropertyInfo propertyInfo =
            typeof(T).GetProperty("IsApiEndpointCaseSensitive", BindingFlags.Static | BindingFlags.NonPublic);
        return propertyInfo == null ? false : (bool)propertyInfo.GetValue(null);
    }
}