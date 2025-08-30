namespace CityManagementApp
{
    public class CityTask
    {
        public int Id { get; set; }

        public required string Details { get; set; }

        public bool IsAccepted { get; set; }

        public string Status { get { return IsAccepted ? "Active" : "Pending"; } }
    }
}
