using CityManagementApp.Auth;
using System.ComponentModel;
using System.Windows;

namespace CityManagementApp.Models
{
    public abstract class AcceptableItemBase : INotifyPropertyChanged
    {
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

        // Each subclass defines which permission is required
        protected abstract string RequiredPermission { get; }

        public Visibility AcceptButtonVisibility =>
            !IsAccepted && SessionStore.Permissions.Contains(RequiredPermission)
                ? Visibility.Visible
                : Visibility.Collapsed;

        public string Status => IsAccepted ? "Accepted" : "Pending";

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
