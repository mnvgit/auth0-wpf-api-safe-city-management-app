using CityManagementApi.Data;

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
    }
}
