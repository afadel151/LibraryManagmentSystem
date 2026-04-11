namespace Borrowing.Web.Services;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Borrowing.SharedClasses.Common;
using Borrowing.SharedClasses.Responses.Adherent;
using System.Net;
using LibraryManagement.Shared.Models;
using Borrowing.Web.Providers;

public interface IExemplaireService
{
    Task<Exemplaire?> GetExemplaireAsync(string id);
    Task<PagedResult<ExemplaireBloqueDto>?> GetExemplaireBloquesAsync(PaginatedQueryParameters parameters);
    // Task<List<TopLoanedNoticeDto>> GetChartData();
    // Task<PagedResult<NoticeDto>> GetNoticesAsync(PaginatedQueryParameters queryParameters);

    // Task<NoticeProfileDto?> GetNoticeProfileAsync(int Id);
}


public class ExemplaireService(ApiHttpClient api) : IExemplaireService
{
    private readonly ApiHttpClient _api = api;
    public async Task<Exemplaire?> GetExemplaireAsync(string id) =>
         await _api.GetAsync<Exemplaire?>("api/Notice/Exemplaire?Id=" + id);

    public async Task<PagedResult<ExemplaireBloqueDto>?> GetExemplaireBloquesAsync(PaginatedQueryParameters queryParameters)
    {
        Console.WriteLine("### requesting...");
        var orderBy = string.IsNullOrWhiteSpace(queryParameters.OrderBy)
                  ? "datepret desc"
                  : queryParameters.OrderBy;
        var url = $"api/Notice/Exemplaire/Bloques?" +
                  $"PageNumber={queryParameters.PageNumber}&" +
                  $"PageSize={queryParameters.PageSize}&" +
                  $"Search={Uri.EscapeDataString(queryParameters.Search ?? "")}&" +
                  $"OrderBy={Uri.EscapeDataString(orderBy)}";

        return await _api.GetAsync<PagedResult<ExemplaireBloqueDto>>(url);
    }

}