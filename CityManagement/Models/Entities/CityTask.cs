namespace CityManagementApi.Models.Entities
{
    public class CityTask
    {
        public int Id { get; set; }

        public required string Details { get; set; }

        public bool IsAccepted { get; set; }
    }
}
