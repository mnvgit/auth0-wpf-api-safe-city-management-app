using CityManagementApi.Models;

namespace CityManagementApi.Services
{
    public interface ICityTaskService
    {
        Task<IEnumerable<CityTask>> GetAllTasksAsync();
        Task<CityTask> CreateTaskAsync(CityTask task);
        Task<bool> AcceptTaskAsync(int taskId);

    }
}
