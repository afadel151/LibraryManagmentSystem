namespace Borrowing.Web.Services;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Common;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.SharedClasses.Responses.Notice;
public interface IAdherentService
{
    Task<AdherentsStatsDto> GetStats();
    Task<PagedResult<AdherentDto>> GetPretsAsync(PaginatedQueryParameters queryParameters);
}


public class AdherentService(HttpClient httpClient) : IAdherentService
{   
    private readonly HttpClient _httpClient = httpClient;

    public async Task<PagedResult<AdherentDto>> GetPretsAsync(PaginatedQueryParameters queryParameters)
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

        // response.EnsureSuccessStatusCode();

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

}