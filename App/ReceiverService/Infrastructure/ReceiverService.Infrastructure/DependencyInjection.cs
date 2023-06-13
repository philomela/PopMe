using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReceiverService.Application.Common.Interfaces;
using ReceiverService.Domain.Interfaces;

namespace ReceiverService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config["DbConnection"];

        services.AddDbContext<ReceiverDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IReceiverDbContext>(provider => provider.GetService<ReceiverDbContext>());

        services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>(provider
            => new SqlConnectionFactory(connectionString));

        return services;
    }
}
