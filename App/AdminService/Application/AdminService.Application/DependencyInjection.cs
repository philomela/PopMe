using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace AdminService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAppication(this IServiceCollection services)
    {
        return services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}
