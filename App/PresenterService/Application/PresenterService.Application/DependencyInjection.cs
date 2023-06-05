using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PresenterService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
        => services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
}