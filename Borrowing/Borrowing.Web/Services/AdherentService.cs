namespace Borrowing.Web.Services;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Borrowing.SharedClasses.Common;
using Borrowing.SharedClasses.Responses.Adherent;
using System.Net;

public interface IAdherentService
{

    Task<AdherentsStatsDto> GetStats();
    Task<AdherentProfileDto?> GetAdherent(string id);
    Task<PagedResult<AdherentDto>> GetAdherentsAsync(PaginatedQueryParameters queryParameters);
}


public class AdherentService(HttpClient httpClient) : IAdherentService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<PagedResult<AdherentDto>> GetAdherentsAsync(PaginatedQueryParameters queryParameters)
    {
        var orderBy = string.IsNullOrWhiteSpace(queryParameters.OrderBy)
                   ? "DatePret desc"
                   : queryParameters.OrderBy;
        var url = $"api/Adherent?" +
                $"PageNumber={queryParameters.PageNumber}&" +
                $"PageSize={queryParameters.PageSize}&" +
                $"Search={queryParameters.Search}&" +
                $"OrderBy={orderBy}";

        var response = await _httpClient.GetAsync(url);

        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();

        return JsonSerializer.Deserialize<PagedResult<AdherentDto>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task<AdherentsStatsDto> GetStats()
    {
        var response = await _httpClient.GetAsync("api/Adherent/Stats");
        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();
        return JsonSerializer.Deserialize<AdherentsStatsDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }
    public async Task<AdherentProfileDto?> GetAdherent(string id)
    {
        var response = await _httpClient.GetAsync("api/Adherent/Profile?Id=" + id);
        var content = await response.Content.ReadAsStringAsync();
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return JsonSerializer.Deserialize<AdherentProfileDto>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        }
        else
        {
            return null;
        }

    }
}