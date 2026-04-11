namespace Borrowing.Web.Services;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Borrowing.SharedClasses.Models;
using Borrowing.SharedClasses.Responses.Adherent;
using System.Net;
using Borrowing.Web.Providers;
public interface INoticeService
{

    Task<List<TopLoanedNoticeDto>?> GetChartData();
    Task<PagedResult<NoticeDto>?> GetNoticesAsync(PaginatedQueryParameters queryParameters);
    Task<List<NoticeDto>?> GetAllNoticesAsync(string search = "");
    Task<NoticeProfileDto?> GetNoticeProfileAsync(int Id);
}


public class NoticeService(ApiHttpClient api) : INoticeService
{
    private readonly ApiHttpClient _api = api;

    public async Task<PagedResult<NoticeDto>?> GetNoticesAsync(PaginatedQueryParameters queryParameters)
    {
        var orderBy = string.IsNullOrWhiteSpace(queryParameters.OrderBy)
                   ? "Cote asc"
                   : queryParameters.OrderBy;
        var url = $"api/Notice?" +
                $"PageNumber={queryParameters.PageNumber}&" +
                $"PageSize={queryParameters.PageSize}&" +
                $"Search={queryParameters.Search}&" +
                $"OrderBy={orderBy}";

        return await _api.GetAsync<PagedResult<NoticeDto>?>(url);

    }


    public async Task<List<TopLoanedNoticeDto>?> GetChartData()
    {
        return await _api.GetAsync<List<TopLoanedNoticeDto>?>("api/Notice/Chart");
        
    }
    public async Task<NoticeProfileDto?> GetNoticeProfileAsync(int Id)
    {
        return await _api.GetAsync<NoticeProfileDto>("api/Notice/Profile?Id=" + Id);
    }

    public async Task<List<NoticeDto>?> GetAllNoticesAsync(string search = "")
    {
        var queryParams = new PaginatedQueryParameters
        {
            PageNumber = 1,
            PageSize = int.MaxValue,
            OrderBy = "Cote asc",
            Search = search
        };

        var result = await GetNoticesAsync(queryParams);
        return result?.Data;
    }
}