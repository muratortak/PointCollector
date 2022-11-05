
using PointCollector.Application;
using PointCollector.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();
