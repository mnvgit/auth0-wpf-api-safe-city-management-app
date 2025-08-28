using CityManagementApi.Data;
using CityManagementApi.Models.Entities;

namespace CityManagementApi
{
    public static class WebApplicationExtension
    {
        public static WebApplication AddProjectEndpoints(this WebApplication app)
        {
            app.MapGet("/projects", async (ICityBuildProjectRepository repository) =>
            {
                return await repository.GetAllProjectsAsync();
            });

            app.MapGet("/projects/accepted", async (ICityBuildProjectRepository repository) =>
            {
                return await repository.GetAcceptedProjectsAsync();
            });

            app.MapPost("/project", async (ICityBuildProjectRepository repository, CityBuildProject project) =>
            {
                return await repository.CreateProjectsAsync(project);
            });

            app.MapPatch("/project/{projectId}/accept", async (ICityBuildProjectRepository repository, int projectId) =>
            {
                return await repository.AcceptProjectsAsync(projectId);
            });

            return app;
        }

        public static WebApplication AddTaskEndpoints(this WebApplication app)
        {
            app.MapGet("/tasks", async (ICityTaskRepository repository) =>
            {
                return await repository.GetAllTasksAsync();
            });

            app.MapGet("/tasks/accepted", async (ICityTaskRepository repository) =>
            {
                return await repository.GetAcceptedTasksAsync();
            });

            app.MapPost("/task", async (ICityTaskRepository repository, CityTask task) =>
            {
                return await repository.CreateTaskAsync(task);
            });

            app.MapPatch("/task/{taskId}/accept", async (ICityTaskRepository repository, int taskId) =>
            {
                return await repository.AcceptTaskAsync(taskId);
            });

            return app;
        }
    }
}
