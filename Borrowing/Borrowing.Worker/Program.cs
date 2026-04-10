using Borrowing.Worker.Extensions;
using Borrowing.Worker;
using Shared.Data;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWorkerServices();

builder.Services.AddHostedService<Worker>();


// builder.Services.AddSystemd();

var host = builder.Build();
host.Run();
