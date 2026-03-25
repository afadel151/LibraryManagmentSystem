namespace Borrowing.Web.Services;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Common;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Responses.Notice;

public class BorrowingService : IBorrowingService
{
    private readonly HttpClient _httpClient;

    public BorrowingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PagedResult<PretResponseDto>> GetPretsAsync(PretQueryParameters query)
    {
        var orderBy = string.IsNullOrWhiteSpace(query.OrderBy)
                ? "DatePret desc"
                : query.OrderBy;
        var url = $"api/Borrowing?" +
                $"PageNumber={query.PageNumber}&" +
                $"PageSize={query.PageSize}&" +
                $"OrderBy={orderBy}";

        var response = await _httpClient.GetAsync(url);

        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();

        return JsonSerializer.Deserialize<PagedResult<PretResponseDto>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task<PretStatsDto> GetStats()
    {
        var response = await _httpClient.GetAsync("api/Borrowing/Stats");
        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();
        return JsonSerializer.Deserialize<PretStatsDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task<CheckAdhResponseDto> CheckAdherent(string id)
    {
        var response = await _httpClient.GetAsync($"api/Adherent/Pret/Check/{id}");
        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();
        return JsonSerializer.Deserialize<CheckAdhResponseDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task<CheckNoticeResponseDto> CheckNotice(string cote, string AdherentId)
    {
        var response = await _httpClient.GetAsync($"api/Notice/Pret/Check/{cote}/{AdherentId}");
        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();
        return JsonSerializer.Deserialize<CheckNoticeResponseDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }
}
