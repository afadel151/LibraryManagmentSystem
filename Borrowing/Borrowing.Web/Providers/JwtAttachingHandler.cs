using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace Borrowing.Web.Providers;

public class JwtAttachingHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public JwtAttachingHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = _httpContextAccessor.HttpContext?.Request.Cookies["authToken"];

        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
            Console.WriteLine($"[JwtAttachingHandler] attached token to {request.RequestUri}");
        }
        else
        {
            Console.WriteLine($"[JwtAttachingHandler] no token for {request.RequestUri}");
        }

        return await base.SendAsync(request, cancellationToken);
    }
}