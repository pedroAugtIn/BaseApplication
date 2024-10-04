using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BaseApplication.Infra.Context;

namespace BaseApplication.Infra.Configurations;

public static class ConfigureHealthChecks
{
    public static void ConfigureDependenciesHealthCheck(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>("Msu Context")
            .AddNpgSql(connectionString: configuration.GetConnectionString("Base"), name: "BaseApi");
    }

    public static void UseHealthCheckConfiguration(this IApplicationBuilder app)
    {
        app.UseHealthChecks("/health", new HealthCheckOptions()
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
    }
}