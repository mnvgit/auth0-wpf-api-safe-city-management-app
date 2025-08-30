namespace CityManagementApi.Models
{
    public class CityBuildProject
    {
        public int Id { get; set; }

        public required string Details { get; set; }
        public required decimal Budget { get; set; }

        public bool IsAccepted { get; set; }
    }
}
