using Microsoft.AspNetCore.Mvc.Infrastructure;
using PointCollector.API;
using PointCollector.API.Common.ExceptionHandling;
using PointCollector.API.Errors;
using PointCollector.Application;
using PointCollector.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    
    // TODO: Can be moved in to AddPresentation DI class...
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, PointCollectorProblemDetailsFactory>();

    var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .CreateLogger();

    builder.Logging.ClearProviders();
    builder.Logging.AddSerilog(logger);
    builder.Services.AddSingleton(Log.Logger);
}

var app = builder.Build();
{
    //app.UseExceptionHandler("/error");
    app.UseMiddleware<ExceptionHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
