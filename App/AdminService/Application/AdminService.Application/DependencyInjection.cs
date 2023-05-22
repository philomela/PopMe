using AdminService.Application.Common.Behaviors;
using AdminService.Application.Common.Mappings;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AdminService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAppication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile(new AssemblyMappigProfile(Assembly.GetExecutingAssembly()));
            cfg.AddProfile(new AssemblyMappigProfile(typeof(IMapFrom<>).Assembly));
        });

        return services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
