using Microsoft.Extensions.Hosting;

namespace RTrading.Infrastructure.Backgraund.Background;

public class StrategyLevelHostedService : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}