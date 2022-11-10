using Microsoft.AspNetCore.Mvc.Infrastructure;
using PointCollector.API.Errors;
using PointCollector.Application;
using PointCollector.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, PointCollectorProblemDetailsFactory>();
}

var app = builder.Build();
{
    //app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
