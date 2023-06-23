using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PresenterService.Application.Common.Interfaces;
using PresenterService.Domain.Interfaces;

namespace PresenterService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config["DbConnection"];

        services.AddDbContext<PresenterDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IPresenterDbContext>(provider => provider.GetService<PresenterDbContext>());

        services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>(provider
            => new SqlConnectionFactory(connectionString));

        return services;
    }
}
