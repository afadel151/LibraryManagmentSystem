using System.Net;
using Borrowing.SharedClasses.Models;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Borrowing.Web.Providers;

public class ApiHttpClient(IHttpClientFactory factory, NavigationManager nav, ILogger<ApiHttpClient> logger)
{
    private readonly HttpClient _http = factory.CreateClient("BorrowingApi");
    private readonly NavigationManager _nav = nav;
    private readonly ILogger<ApiHttpClient> _logger = logger;
    public async Task<T?> GetAsync<T>(string url)
    {
        var response = await _http.GetAsync(url);
        return await HandleResponse<T>(response);
    }

    public async Task<T?> PostAsync<T>(string url, object body)
    {
        var response = await _http.PostAsJsonAsync(url, body);
        return await HandleResponse<T>(response);
    }

    public async Task<T?> PutAsync<T>(string url, object body)
    {
        var response = await _http.PutAsJsonAsync(url, body);
        return await HandleResponse<T>(response);
    }

    public async Task DeleteAsync(string url)
    {
        var response = await _http.DeleteAsync(url);
        await HandleResponse<object>(response);
    }

    private async Task<T?> HandleResponse<T>(HttpResponseMessage response)
    {
        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            _nav.NavigateTo("/Login", forceLoad: true);
            return default;
        }

        if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
        {
            _nav.NavigateTo("/unauthorized", forceLoad: true);
            return default;
        }
        response.EnsureSuccessStatusCode();

        if (typeof(T) == typeof(object)) return default;
        return await response.Content.ReadFromJsonAsync<T>();
    }
    public async Task<bool> PostForSuccessAsync(string url, object body)
    {
        var response = await _http.PostAsJsonAsync(url, body);
        return await HandleSuccessResponse(response);
    }

    public async Task<bool> PutForSuccessAsync(string url, object body)
    {
        var response = await _http.PutAsJsonAsync(url, body);
        return await HandleSuccessResponse(response);
    }

    public async Task<bool> DeleteForSuccessAsync(string url)
    {
        var response = await _http.DeleteAsync(url);
        return await HandleSuccessResponse(response);
    }

    private Task<bool> HandleSuccessResponse(HttpResponseMessage response)
    {
        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            _nav.NavigateTo("/Login", forceLoad: true);
            return Task.FromResult(false);
        }

        if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
        {
            _nav.NavigateTo("/unauthorized", forceLoad: true);
            return Task.FromResult(false);
        }

        return Task.FromResult(response.IsSuccessStatusCode);
    }
    public async Task<ApiResult> PostForResultAsync(string url, object body)
    {
        var response = await _http.PostAsJsonAsync(url, body);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            _nav.NavigateTo("/Login", forceLoad: true);
            return ApiResult.Fail("Non autorisé.", "UNAUTHORIZED");
        }

        if (response.StatusCode == HttpStatusCode.Forbidden)
        {
            _nav.NavigateTo("/unauthorized", forceLoad: true);
            return ApiResult.Fail("Accès refusé.", "FORBIDDEN");
        }

        if (!response.IsSuccessStatusCode)
            return ApiResult.Fail($"Erreur HTTP {(int)response.StatusCode}.", "HTTP_ERROR");

        return await response.Content.ReadFromJsonAsync<ApiResult>()
               ?? ApiResult.Fail("Réponse vide du serveur.", "EMPTY_RESPONSE");
    }
}