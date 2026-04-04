using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;

namespace Borrowing.Web.Components.Base;

public abstract class AuthorizedComponentBase : ComponentBase
{
    [Inject] protected NavigationManager Nav { get; set; } = default!;
    [Inject] protected AuthenticationStateProvider AuthStateProvider { get; set; } = default!;

    private bool _dataLoaded = false;

    // Override this in your pages instead of OnInitializedAsync / OnAfterRenderAsync
    protected virtual Task OnPageInitializedAsync() => Task.CompletedTask;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender || _dataLoaded) return;
        _dataLoaded = true;

        // Check auth state first
        bool isAuthenticated = false;
        for (int i = 0; i < 3; i++)
        {
            var authState = await AuthStateProvider.GetAuthenticationStateAsync();
            isAuthenticated = authState.User.Identity?.IsAuthenticated ?? false;
            if (isAuthenticated) break;
            await Task.Delay(200); // wait for JS interop to become available
        }

        if (!isAuthenticated)
        {
            Nav.NavigateTo("/Login", forceLoad: true);
            return;
        }
        // Safe to call API now
        try
        {
            await OnPageInitializedAsync();
            StateHasChanged();
        }
        catch (HttpRequestException ex) when ((int?)ex.StatusCode == 401)
        {
            Nav.NavigateTo("/Login", forceLoad: true);
        }
        catch (HttpRequestException ex) when ((int?)ex.StatusCode == 403)
        {
            Nav.NavigateTo("/unauthorized", forceLoad: true);
        }
    }
}