using CityManagementApi.Models;

namespace CityManagementApi.Services
{
    public interface ICityBuildProjectService
    {
        Task<IEnumerable<CityBuildProject>> GetAllProjectsAsync();
        Task<CityBuildProject> CreateProjectsAsync(CityBuildProject task);
        Task<bool> AcceptProjectsAsync(int projectId);

    }
}
