using Microsoft.AspNetCore.Mvc.Infrastructure;
using PointCollector.API;
using PointCollector.API.Errors;
using PointCollector.Application;
using PointCollector.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    
    // TODO: Can be moved in to AddPresentation DI class...
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, PointCollectorProblemDetailsFactory>();
}

var app = builder.Build();
{
    //app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
