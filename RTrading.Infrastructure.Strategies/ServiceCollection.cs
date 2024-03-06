using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RTrading.Infrastructure.Strategies.Strategies;
using RTraiding.Application.Domains.Options;

namespace RTrading.Infrastructure.Strategies;

public static class ServiceCollection
{
    public static void AddInfrastructureStrategies(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<LevelStrategyOption>(configuration.GetSection("LevelStrategyOption"));
        services.AddTransient<LevelStrategy>();
    }
}