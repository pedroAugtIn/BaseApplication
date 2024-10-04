using BaseApplication.Domain.Interfaces.Repositories;
using BaseApplication.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BaseApplication.Infra.Configurations;

public static class ConfigureRepositories
{
    public static void ConfigureDependenciesRepository(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
    }
}