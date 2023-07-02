using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace JwtAuth;

public static class JwtAuthSchemeDependencyInjection
{
    public static IServiceCollection AddCustomAuthScheme(this IServiceCollection services, Action<JwtBearerOptions>? configureOptions = null)
    {
        if (services is not null)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            if (configureOptions is not null)
            {
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, configureOptions);
            }

            return services;
        }
        else { throw new ArgumentNullException(); }
    }
}