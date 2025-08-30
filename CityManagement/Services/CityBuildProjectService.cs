using CityManagementApi.Models;

namespace CityManagementApi.Services
{
    public class CityBuildProjectService : ICityBuildProjectService
    {
        private readonly List<CityBuildProject> _cityBuildProjects;

        private int ProjectId = 1;

        public CityBuildProjectService()
        {
            _cityBuildProjects =
            [
                //Init samples
                new CityBuildProject
                {
                    Id = ProjectId++,
                    Details = "Build supermarket",
                    Budget = 1000000
                },
                new CityBuildProject
                {
                    Id = ProjectId++,
                    Details = "Build business center",
                    Budget = 2000000   
                },
            ];
        }

        public Task<IEnumerable<CityBuildProject>> GetAllProjectsAsync()
        {
            return Task.FromResult<IEnumerable<CityBuildProject>>(_cityBuildProjects);
        }

        public Task<CityBuildProject> CreateProjectsAsync(CityBuildProject project)
        {
            project.Id = ProjectId++;
            _cityBuildProjects.Add(project);
            return Task.FromResult(project);
        }

        public Task<bool> AcceptProjectsAsync(int projectId)
        {
            var projectToAccept = _cityBuildProjects.FirstOrDefault(t => t.Id == projectId);
            projectToAccept.IsAccepted = true;
            return Task.FromResult(projectToAccept.IsAccepted);
        }
    }
}
