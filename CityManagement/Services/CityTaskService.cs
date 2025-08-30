using CityManagementApi.Models;

namespace CityManagementApi.Services
{
    public class CityTaskService : ICityTaskService
    {
        private readonly List<CityTask> _cityTasks;

        private int UserId = 1;

        public CityTaskService()
        {
            _cityTasks =
            [
                //Init samples
                new CityTask
                {
                    Id = UserId++,
                    Task = "Plant trees",
                    Department = CityDepartments.Garden
                },
                new CityTask
                {
                    Id = UserId++,
                    Task = "Paint crosswalk",
                    Department = CityDepartments.Streets
                },
            ];
        }

        public Task<IEnumerable<CityTask>> GetAllTasksAsync()
        {
            return Task.FromResult<IEnumerable<CityTask>>(_cityTasks);
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
