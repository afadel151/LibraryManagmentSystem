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
    Task<IEnumerable<AdherentDto>> GetAllAdherentsAsync(string search = "");
    Task<bool> CreateAdherentAsync(Borrowing.SharedClasses.Requests.Adherent.CreateAdherentDto dto);
    Task<bool> DeletePenaliteAsync(string adherentId, DateTime datePenalite);
}


public class AdherentService(IHttpClientFactory factory) : IAdherentService
{
    private readonly HttpClient _httpClient = factory.CreateClient("BorrowingApi");

    public async Task<bool> CreateAdherentAsync(Borrowing.SharedClasses.Requests.Adherent.CreateAdherentDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Adherent", dto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeletePenaliteAsync(string adherentId, DateTime datePenalite)
    {
        var response = await _httpClient.DeleteAsync($"api/Penalite/{adherentId}/{datePenalite:yyyy-MM-ddTHH:mm:ss}");
        return response.IsSuccessStatusCode;
    }

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

    public async Task<IEnumerable<AdherentDto>> GetAllAdherentsAsync(string search = "")
    {
        var queryParams = new PaginatedQueryParameters
        {
            PageNumber = 1,
            PageSize = int.MaxValue,
            OrderBy = "datepret desc",
            Search = search
        };

        var result = await GetAdherentsAsync(queryParams);
        return result.Data;
    }
}