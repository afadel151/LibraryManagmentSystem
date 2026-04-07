using Borrowing.Worker.Services;
using Shared.Data;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();
builder.Services.AddDbContext<LibraryDbContext>();

builder.Services.AddSystemd();
var host = builder.Build();
host.Run();
