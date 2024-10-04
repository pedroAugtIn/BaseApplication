using BaseApplication.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseApplication.Infra.Configurations;

public static class ConfigureDatabases
{
    public static void ConfigureDependenciesDatabase(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("Base"))
                .UseLazyLoadingProxies()
        );

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}