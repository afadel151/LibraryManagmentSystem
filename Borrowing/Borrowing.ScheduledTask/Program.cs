using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Borrowing.ScheduledTask.Extensions;
using Borrowing.ScheduledTask.Services;
using Microsoft.Extensions.Logging;

var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var services = new ServiceCollection();
services.AddDbContext<LibraryDbContext>();
services.AddTaskServices();
services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.SetMinimumLevel(LogLevel.Information);
});
var provider = services.BuildServiceProvider();

// 3. Run the job
Console.WriteLine($"[{DateTime.Now}] Starting loan check...");

try
{
    using var scope = provider.CreateScope();
    var pretsChecker = scope.ServiceProvider.GetRequiredService<IScopedPretService>();
    var penaltyCHekcer = scope.ServiceProvider.GetRequiredService<IScopedPenaltieService>();
    await pretsChecker.Run();
    Console.WriteLine($"[{DateTime.Now}] Loan check completed successfully.");
}
catch (Exception ex)
{
    Console.WriteLine($"[{DateTime.Now}] ERROR: {ex.Message}");
    Environment.Exit(1); 
}

Environment.Exit(0); 