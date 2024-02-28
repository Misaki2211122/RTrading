using System.Reflection;
using MediatR;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RTraiding.Application.Domains.Mappings;

namespace RTraiding.Application;

public static class ServiceCollection
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(ServiceCollection).GetTypeInfo().Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }

}