using CityManagementApp.Auth;
using System.ComponentModel;
using System.Windows;

namespace CityManagementApp
{
    public class CityTask : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Details { get; set; } = "";

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

        public Visibility AcceptButtonVisibility => !IsAccepted && SessionStore.Permissions.Contains("update:projects")
                                           ? Visibility.Visible
                                           : Visibility.Collapsed;

        public string Status => IsAccepted ? "Accepted" : "Pending";

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
