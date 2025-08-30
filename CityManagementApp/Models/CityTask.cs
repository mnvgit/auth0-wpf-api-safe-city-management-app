using CityManagementApp.Auth;
using System.ComponentModel;
using System.Windows;

namespace CityManagementApp
{
    public class CityTask : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Task { get; set; } = "";

        public CityDepartment Department { get; set; }


        private bool _isAccepted;
        public bool IsAccepted
        {
            get => _isAccepted;
            set
            {
                _isAccepted = value;
                OnPropertyChanged(nameof(IsAccepted));
                OnPropertyChanged(nameof(AcceptButtonVisibility));
                OnPropertyChanged(nameof(Status));
            }
        }

        public Visibility AcceptButtonVisibility => !IsAccepted && SessionStore.Permissions.Contains("update:tasks")
                                           ? Visibility.Visible
                                           : Visibility.Collapsed;

        public string DepartmentName => Department.ToString();

        public string Status => IsAccepted ? "Accepted" : "Pending";

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
