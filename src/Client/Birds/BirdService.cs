using System.Net.Http.Json;
using Shared.Birds;

namespace Client.Birds;

public class BirdService : IBirdService
{
    private readonly HttpClient client;
    private const string endpoint = "api/bird";
    public BirdService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<IEnumerable<BirdDto.Index>> GetIndexAsync()
    {
        var response = await client.GetFromJsonAsync<IEnumerable<BirdDto.Index>>($"{endpoint}");
        return response!;
    }

    public async Task SpotAsync(BirdDto.Spot request)
    {
        var response = await client.PostAsJsonAsync(endpoint, request);
        response.EnsureSuccessStatusCode();
    }
}
