namespace Borrowing.Web.Services;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Borrowing.SharedClasses.Models;
using Borrowing.SharedClasses.Responses.Adherent;
using System.Net;

public interface INoticeService
{

    Task<List<TopLoanedNoticeDto>> GetChartData();
    Task<PagedResult<NoticeDto>> GetNoticesAsync(PaginatedQueryParameters queryParameters);
    Task<IEnumerable<NoticeDto>> GetAllNoticesAsync(string search = "");
    Task<NoticeProfileDto?> GetNoticeProfileAsync(int Id);
}


public class NoticeService(IHttpClientFactory factory) : INoticeService
{
    private readonly HttpClient _httpClient = factory.CreateClient("BorrowingApi");

    public async Task<PagedResult<NoticeDto>> GetNoticesAsync(PaginatedQueryParameters queryParameters)
    {
        var orderBy = string.IsNullOrWhiteSpace(queryParameters.OrderBy)
                   ? "Cote asc"
                   : queryParameters.OrderBy;
        var url = $"api/Notice?" +
                $"PageNumber={queryParameters.PageNumber}&" +
                $"PageSize={queryParameters.PageSize}&" +
                $"Search={queryParameters.Search}&" +
                $"OrderBy={orderBy}";

        var response = await _httpClient.GetAsync(url);

        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();

        return JsonSerializer.Deserialize<PagedResult<NoticeDto>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    
    public async Task<List<TopLoanedNoticeDto>> GetChartData()
    {
        var response = await _httpClient.GetAsync("api/Notice/Chart");
        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();
        return JsonSerializer.Deserialize<List<TopLoanedNoticeDto>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }
    public async Task<NoticeProfileDto?> GetNoticeProfileAsync(int Id)
    {
        var response = await _httpClient.GetAsync("api/Notice/Profile?Id=" + Id);
        var content = await response.Content.ReadAsStringAsync();
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return JsonSerializer.Deserialize<NoticeProfileDto>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        }
        else
        {
            return null;
        }

        
    }

    public async Task<IEnumerable<NoticeDto>> GetAllNoticesAsync(string search = "")
    {
        var queryParams = new PaginatedQueryParameters
        {
            PageNumber = 1,
            PageSize = int.MaxValue,
            OrderBy = "Cote asc",
            Search = search
        };

        var result = await GetNoticesAsync(queryParams);
        return result.Data;
    }
}