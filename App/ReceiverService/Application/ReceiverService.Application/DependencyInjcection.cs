using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ReceiverService.Application.Common.Behaviors;
using ReceiverService.Application.Common.Mappings;
using System.Reflection;

namespace ReceiverService.Application;

public static class DependencyInjcection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
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