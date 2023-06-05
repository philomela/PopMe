using AdminService.Application.Common.Interfaces;
using AdminService.Domain.Interfaces;
using AdminService.Infrastructure.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdminService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config["DbConnection"];

        services.AddDbContext<AdminDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IAdminDbContext>(provider => provider.GetService<AdminDbContext>());
        services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>(provider 
            => new SqlConnectionFactory(connectionString));

        services.AddTransient<IQrCodeClient<string>, QrCodeClient>();

        return services;
    }
}
