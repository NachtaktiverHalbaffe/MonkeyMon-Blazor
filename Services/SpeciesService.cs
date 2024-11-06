using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MonkeyMon_Blazor.Infrastructure;
using MonkeyMon_Blazor.Models;
using MonkeyMon_Blazor.Properties;

namespace MonkeyMon_Blazor.Services;

public class SpeciesService(ApplicationDbContext dbContext, HttpClient client, IOptions<SpeciesApiSettings> apiSettings)
{
    public async Task<ICollection<Species>> GetAll()
    {
        return await dbContext.Species.ToListAsync();
    }

    public async Task<Species?> GetByName(string name)
    {
        var existingSpecies =
            await dbContext.Species.SingleOrDefaultAsync(s => s.Name.ToLower().Contains(name.ToLower()));

        if (existingSpecies is null)
        {
            var fetchedSpecies = await FetchSpecies(name);

            if (fetchedSpecies is not null)
            {
                await dbContext.Species.AddAsync(fetchedSpecies);
                await dbContext.SaveChangesAsync();

                return fetchedSpecies;
            }

            return null;
        }

        return existingSpecies;
    }

    public async Task<Species?> FetchSpecies(string name)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"/v1/animals?name={name}");

        var response = await client.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var responseContent = await response.Content.ReadAsStreamAsync();

        var deserialzedResponse = await JsonSerializer.DeserializeAsync<SpeciesApiResponse>(responseContent);

        return deserialzedResponse is not null
            ? new Species
            {
                Name = deserialzedResponse.Name,
                Locations = deserialzedResponse.Locations,
                Characteristics = deserialzedResponse.Characteristics,
                Taxonomy = deserialzedResponse.Taxonomy
            }
            : null;
    }
}