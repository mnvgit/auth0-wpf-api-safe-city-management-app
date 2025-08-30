using CityManagementApi.Models;
using CityManagementApi.Services;

namespace CityManagementApi
{
    public static class WebApplicationExtension
    {
        public static WebApplication AddProjectEndpoints(this WebApplication app)
        {
            // Everyone can see projects
            app.MapGet("/projects", async (ICityBuildProjectService repository) =>
            {
                return await repository.GetAllProjectsAsync();
            });

            // Only users(mid and top level managers) with "create:projects" permission can create projects
            app.MapPost("/project", async (ICityBuildProjectService repository, CityBuildProject project) =>
            {
                return await repository.CreateProjectsAsync(project);
            })
            .RequireAuthorization("create:projects");

            // Only users(top level managers) with "update:projects" permission can accept projects
            app.MapPatch("/project/{projectId}/accept", async (ICityBuildProjectService repository, int projectId) =>
            {
                return await repository.AcceptProjectsAsync(projectId);
            })
            .RequireAuthorization("update:projects");

            return app;
        }

        public static WebApplication AddTaskEndpoints(this WebApplication app)
        {
            // Everyone can see tasks
            app.MapGet("/tasks", async (ICityTaskService repository) =>
            {
                return await repository.GetAllTasksAsync();
            });

            // Everyone can create tasks
            app.MapPost("/task", async (ICityTaskService repository, CityTask task) =>
            {
                return await repository.CreateTaskAsync(task);
            });

            // Only users(mid and top level managers) with "update:tasks" permission can accept tasks
            app.MapPatch("/task/{taskId}/accept", async (ICityTaskService repository, int taskId) =>
            {
                return await repository.AcceptTaskAsync(taskId);
            })
            .RequireAuthorization("update:tasks");

            return app;
        }
    }
}
