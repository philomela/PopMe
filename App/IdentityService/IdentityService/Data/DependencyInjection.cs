using IdentityService.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using JwtAuth;
using IdentityService.Services;

namespace IdentityService.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIdentityInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["DbConnection"];

            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
            }).AddEntityFrameworkStores<AuthDbContext>().AddDefaultTokenProviders();

            services.AddCustomAuthScheme();

            services.AddTransient<IJwtGenerator<AppUser>, JwtGenerator>();

            return services;
        }
    }
}
