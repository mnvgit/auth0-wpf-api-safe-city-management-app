using CityManagementApi.Models.Entities;

namespace CityManagementApi.Data
{
    public class CityBuildProjectRepository : ICityBuildProjectRepository
    {
        private readonly List<CityBuildProject> _cityBuildProjects;

        private int ProjectId = 1;

        public CityBuildProjectRepository()
        {
            _cityBuildProjects =
            [
                //Init samples
                new CityBuildProject
                {
                    Id = ProjectId++,
                    Details = "Build supermarket"
                },
                new CityBuildProject
                {
                    Id = ProjectId++,
                    Details = "Build bussines center"
                },
            ];
        }

        public Task<IEnumerable<CityBuildProject>> GetAllProjectsAsync()
        {
            return Task.FromResult<IEnumerable<CityBuildProject>>(_cityBuildProjects);
        }

        public Task<IEnumerable<CityBuildProject>> GetAcceptedProjectsAsync()
        {
            return Task.FromResult(_cityBuildProjects.Where(p => p.IsAccepted));
        }

        public Task<CityBuildProject> CreateProjectsAsync(CityBuildProject project)
        {
            project.Id = ProjectId++;
            _cityBuildProjects.ToList().Add(project);
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
