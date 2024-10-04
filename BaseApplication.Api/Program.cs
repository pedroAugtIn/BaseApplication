using Microsoft.EntityFrameworkCore;
using BaseApplication.Infra.Configurations;
using BaseApplication.Infra.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy",
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.ConfigureDependenciesHealthCheck(builder.Configuration);
builder.Services.ConfigureDependenciesService();
builder.Services.ConfigureDependenciesRepository();
builder.Services.ConfigureDependenciesDatabase(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwaggerConfiguration();
}
app.MigrateDatabase();
app.UseHealthCheckConfiguration();
app.UseCors("CorsPolicy");
app.MapControllers();
app.Run();