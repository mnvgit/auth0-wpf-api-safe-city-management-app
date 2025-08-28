namespace CityManagementApi.Models.Entities
{
    public class CityBuildProject
    {
        public int Id { get; set; }

        public required string Details { get; set; }

        public bool IsAccepted { get; set; }
    }
}
