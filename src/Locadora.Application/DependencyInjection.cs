using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Locadora.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}