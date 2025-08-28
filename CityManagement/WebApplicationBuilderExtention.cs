using CityManagementApi.Auth;
using CityManagementApi.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace CityManagementApi
{
    public static class WebApplicationBuilderExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<ICityBuildProjectRepository, CityBuildProjectRepository>();
            services.AddSingleton<ICityTaskRepository, CityTaskRepository>();
            return services;
        }

        public static IServiceCollection AddAuthSettings(this IServiceCollection services, IConfigurationManager configuration)
        {
            var domain = $"https://{configuration["Auth0:Domain"]}/";
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = domain;
                    options.Audience = configuration["Auth0:Audience"];
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = ClaimTypes.NameIdentifier
                    };
                });

            services.AddAuthorizationBuilder()
                .SetFallbackPolicy(new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser().Build())
                .AddPolicy("read:tasks", policy => policy.Requirements.Add(new HasScopeRequirement("read:tasks", domain)))
                .AddPolicy("update:tasks", policy => policy.Requirements.Add(new HasScopeRequirement("update:tasks", domain)))

                .AddPolicy("read:projects", policy => policy.Requirements.Add(new HasScopeRequirement("read:projects", domain)))
                .AddPolicy("create:projects", policy => policy.Requirements.Add(new HasScopeRequirement("create:projects", domain)))
                .AddPolicy("update:projects", policy => policy.Requirements.Add(new HasScopeRequirement("update:projects", domain)));

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            return services;
        }
    }
}
