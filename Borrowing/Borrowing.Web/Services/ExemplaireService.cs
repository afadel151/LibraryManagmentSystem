namespace Borrowing.Web.Services;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Borrowing.SharedClasses.Common;
using Borrowing.SharedClasses.Responses.Adherent;
using System.Net;
using Shared.Models;

public interface IExemplaireService
{
    Task<Exemplaire?> GetExemplaireAsync(string id);

    // Task<List<TopLoanedNoticeDto>> GetChartData();
    // Task<PagedResult<NoticeDto>> GetNoticesAsync(PaginatedQueryParameters queryParameters);

    // Task<NoticeProfileDto?> GetNoticeProfileAsync(int Id);
}


public class ExemplaireService(HttpClient httpClient) : IExemplaireService
{
    private readonly HttpClient _httpClient = httpClient;
    public async Task<Exemplaire?> GetExemplaireAsync(string id)
    {
        var response = await _httpClient.GetAsync("api/Notice/Exemplaire?Id=" + id);
        var content = await response.Content.ReadAsStringAsync();
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return JsonSerializer.Deserialize<Exemplaire>(content, new JsonSerializerOptions
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