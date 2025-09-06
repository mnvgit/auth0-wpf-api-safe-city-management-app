using CityManagementApp.Models;

namespace CityManagementApp
{
    public class CityTask : AcceptableItemBase
    {
        public int Id { get; set; }
        public string Task { get; set; } = "";
        public CityDepartment Department { get; set; }

        public string DepartmentName => Department.ToString();

        protected override string RequiredPermission => "update:tasks";
    }
}
