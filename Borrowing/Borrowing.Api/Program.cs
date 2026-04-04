using Borrowing.Api.Extensions;
using Shared.Data;
using Shared.Seeders;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<LibraryDbContext>();
builder.Services.AddBorrowingServices();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath        = "/Account/Login";
        options.LogoutPath       = "/Account/Logout";
        options.AccessDeniedPath = "/Access-Denied";
        options.ExpireTimeSpan   = TimeSpan.FromHours(8);
        options.SlidingExpiration = true;
 
        // Important: for API calls return 401 instead of redirecting
        options.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = ctx =>
            {
                if (ctx.Request.Path.StartsWithSegments("/api"))
                {
                    ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                }
                ctx.Response.Redirect(ctx.RedirectUri);
                return Task.CompletedTask;
            },
            OnRedirectToAccessDenied = ctx =>
            {
                if (ctx.Request.Path.StartsWithSegments("/api"))
                {
                    ctx.Response.StatusCode = StatusCodes.Status403Forbidden;
                    return Task.CompletedTask;
                }
                ctx.Response.Redirect(ctx.RedirectUri);
                return Task.CompletedTask;
            }
        };
    });
 
builder.Services.AddAuthorization();
 
// ── 3. CORS — allow Blazor frontend to send cookies ──────────────────────────
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorFrontend", policy =>
    {
        policy
            .WithOrigins(builder.Configuration["AllowedOrigins"] ?? "https://localhost:7001")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // Required for cookies cross-origin
    });
});
 
// ── 4. Session (used to store redirectUrl if needed) ─────────────────────────
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout  = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("BlazorFrontend");   // Must be before UseAuthentication
app.UseSession();
app.UseAuthentication();         // Order matters: Authentication before Authorization
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
    var seeder = new DatabaseSeeder(context);
    await seeder.SeedAllAsync();
}

app.Run();

/*
Here is exactly how the backend ensures security and processes roles:

### 1. The Encrypted Cookie
During the login process, when your code executes `await HttpContext.SignInAsync(...)`, ASP.NET Core takes the claims you created (Name, Nom, and Role) and serializes them into a highly secure, encrypted, and tamper-proof **Cookie**.

### 2. Automatic Transmission
Because the frontend's `HttpClient` is configured with `UseCookies = true`, it actively holds onto this encrypted cookie. For every subsequent API request the Blazor app makes to the backend (like fetching data or making changes), the `HttpClient` **automatically attaches this cookie** into the [Cookie](cci:2://file:///home/fadel/GitHub/LibraryManagmentSystem/Borrowing/Borrowing.Web/Services/CookieAuthStateProvider.cs:6:0-69:1) Header of the HTTP request.

### 3. Backend Decryption & Authentication (`[Authorize]`)
When the `Borrowing.Api` receives a request, it hits the `app.UseAuthentication()` middleware *before* it reaches your controllers. 
The middleware:
1. Extracts the cookie from the HTTP headers.
2. Decrypts and validates the signature to ensure it wasn't tampered with.
3. Reconstructs the `ClaimsPrincipal` inside `HttpContext.User`.

Because we added the `[Authorize]` attribute to your controllers earlier, if a user tries to hit an endpoint without this valid cookie, the backend immediately rejects it with a `401 Unauthorized` without executing your code.

### 4. Admin Privilege Determination (`[Authorize(Roles = "Admin")]`)
Because the decrypted cookie actively contains the `ClaimTypes.Role` you packed into it during login, the backend knows exactly who they are and what their role is. 

If you want to secure a specific API endpoint so that **only Admins** can use it, you simply append the `Roles` parameter to the attribute like this:

```csharp
[Authorize(Roles = "Admin")]
[HttpDelete("{id}")]
public async Task<IActionResult> DeleteUtilisateur(string id)
{
    // Only an Admin can reach this code.
    // If a normal "Utilisateur" calls this, the backend automatically returns 403 Forbidden.
}
```

This ensures that even if a normal user somehow bypasses the frontend UI or manually sends API requests using tools like Postman, the backend will completely block them!

*/