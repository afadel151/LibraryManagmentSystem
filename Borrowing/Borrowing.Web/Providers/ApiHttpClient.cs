using Microsoft.AspNetCore.Components;

namespace Borrowing.Web.Providers;

public class ApiHttpClient(IHttpClientFactory factory, NavigationManager nav)
{
    private readonly HttpClient _http = factory.CreateClient("BorrowingApi");
    private readonly NavigationManager _nav = nav;

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
}