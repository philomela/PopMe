using AdminService.Domain.Interfaces;
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

        return services;
    }
}
