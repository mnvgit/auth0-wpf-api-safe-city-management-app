namespace CityManagementApi.Models
{
    public class CityTask
    {
        public int Id { get; set; }

        public required string Task { get; set; }

        public required CityDepartments Department { get; set; }

        public bool IsAccepted { get; set; }
    }
}
