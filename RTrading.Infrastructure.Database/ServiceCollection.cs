using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RTading.Infrastructure.Database.Context;

namespace RTading.Infrastructure.Database;

public static class ServiceCollection
{
    /// <summary>
    /// DataBase
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddInfrastructureDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<AnaliticContext>(
            options => { options.UseNpgsql( configuration.GetConnectionString( "DbConnection" ) ); }, ServiceLifetime.Transient );
    }
}