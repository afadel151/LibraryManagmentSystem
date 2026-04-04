using Microsoft.AspNetCore.Components;
using System.Security.Claims;

namespace Borrowing.Web.Components.Base;

public abstract class AuthorizedAdminComponentBase : AuthorizedComponentBase
{
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender) return;

        var authState = await AuthStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (!user.Identity?.IsAuthenticated ?? true)
        {
            Nav.NavigateTo("/Login", forceLoad: true);
            return;
        }

        if (!user.IsInRole("ADMIN"))
        {
            Nav.NavigateTo("/unauthorized", forceLoad: true);
            return;
        }

        await base.OnAfterRenderAsync(firstRender);
    }
}

/*
@page "/prets"
@attribute [Authorize]
@inherits AuthorizedComponentBase
@inject IPretService PretService

@code {
    private Stats stats;

    protected override async Task OnPageInitializedAsync()
    {
        stats = await PretService.GetStats();
        // No try/catch needed — base class handles 401/403
        // No StateHasChanged needed — base class calls it
    }
}
*/