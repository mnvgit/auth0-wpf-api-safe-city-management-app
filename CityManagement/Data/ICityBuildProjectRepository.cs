using CityManagementApi.Models.Entities;

namespace CityManagementApi.Data
{
    public interface ICityBuildProjectRepository
    {
        Task<IEnumerable<CityBuildProject>> GetAllProjectsAsync();
        Task<IEnumerable<CityBuildProject>> GetAcceptedProjectsAsync();
        Task<CityBuildProject> CreateProjectsAsync(CityBuildProject task);
        Task<bool> AcceptProjectsAsync(int projectId);

    }
}
