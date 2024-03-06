using Microsoft.Extensions.DependencyInjection;
using RTrading.Infrastructure.Backgraund.Background;

namespace RTrading.Infrastructure.Backgraund;

public static class ServiceCollection
{
    public static void AddInfrastructureBackgraund(this IServiceCollection services)
    {
        services.AddHostedService<StrategyLevelHostedService>();
    }
}