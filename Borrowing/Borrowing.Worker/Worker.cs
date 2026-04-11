using Borrowing.Worker.Services;

namespace Borrowing.Worker;

public class Worker(ILogger<Worker> logger,IServiceScopeFactory scopeFactory) : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory = scopeFactory;
    private readonly ILogger<Worker> _logger = logger;
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _scopeFactory.CreateScope();
        while (!stoppingToken.IsCancellationRequested)
        {   
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var pretService = scope.ServiceProvider.GetRequiredService<IScopedPretService>();
                await pretService.Run();
            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}
