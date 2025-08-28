using CityManagementApi.Models.Entities;

namespace CityManagementApi.Data
{
    public interface ICityTaskRepository
    {
        Task<IEnumerable<CityTask>> GetAllTasksAsync();
        Task<IEnumerable<CityTask>> GetAcceptedTasksAsync();
        Task<CityTask> CreateTaskAsync(CityTask task);
        Task<bool> AcceptTaskAsync(int taskId);

    }
}
