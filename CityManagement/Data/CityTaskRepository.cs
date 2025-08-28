using CityManagementApi.Data;
using CityManagementApi.Models.Entities;

namespace CityManagementApi.Data
{
    public class CityTaskRepository : ICityTaskRepository
    {
        private readonly List<CityTask> _cityTasks;

        private int UserId = 1;

        public CityTaskRepository()
        {
            _cityTasks =
            [
                //Init samples
                new CityTask
                {
                    Id = UserId++,
                    Details = "Plant trees"
                },
                new CityTask
                {
                    Id = UserId++,
                    Details = "Paint crosswalk"
                },
            ];
        }

        public Task<IEnumerable<CityTask>> GetAllTasksAsync()
        {
            return Task.FromResult<IEnumerable<CityTask>>(_cityTasks);
        }

        public Task<IEnumerable<CityTask>> GetAcceptedTasksAsync()
        {
            return Task.FromResult(_cityTasks.Where(t => t.IsAccepted));
        }

        public Task<CityTask> CreateTaskAsync(CityTask task)
        {
            task.Id = UserId++;
            _cityTasks.Add(task);
            return Task.FromResult(task);
        }

        public Task<bool> AcceptTaskAsync(int taskId)
        {
            var taskToAccept = _cityTasks.FirstOrDefault(t => t.Id == taskId);
            taskToAccept.IsAccepted = true;
            return Task.FromResult(taskToAccept.IsAccepted);
        }
    }
}
