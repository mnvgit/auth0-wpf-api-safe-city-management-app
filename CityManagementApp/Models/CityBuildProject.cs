using CityManagementApp.Models;

namespace CityManagementApp
{
    public class CityBuildProject : AcceptableItemBase
    {
        public int Id { get; set; }
        public required string Details { get; set; }
        public required decimal Budget { get; set; }

        protected override string RequiredPermission => "update:projects";
    }
}
