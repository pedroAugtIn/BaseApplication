using BaseApplication.Domain.AutoMapper;
using BaseApplication.Domain.Interfaces.Services;
using BaseApplication.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BaseApplication.Infra.Configurations;

public static class ConfigureServices
{
    public static void ConfigureDependenciesService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHttpClient();
        serviceCollection.AddAutoMapper(typeof(DomainToViewMappingProfile));
        serviceCollection.AddAutoMapper(typeof(ViewToDomainMappingProfile));
        serviceCollection.AddScoped<IUserService, UserService>();
    }
}