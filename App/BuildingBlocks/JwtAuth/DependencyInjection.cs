using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuth;

public static class DependencyInjection
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

    public static IServiceCollection AddPolicyAuthorization(this IServiceCollection services)
    {
        if (services is not null)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IAuthorizationHandler, UserIdHandler>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("UserIdPolicy", policy =>
                {
                    policy.Requirements.Add(new UserIdRequirement());
                });
            });

            return services;
        }
        else { throw new ArgumentNullException(); }
    }
}
