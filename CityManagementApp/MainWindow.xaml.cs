using CityManagementApp.Auth;

namespace CityManagementApp
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            Loaded += async (_, __) =>
            {
                if (DataContext is MainWindowViewModel vm)
                    await Task.WhenAll(vm.LoadTasksDataAsync(), vm.LoadProjectsDataAsync());
            };
        }

        private async void LogoutButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SessionStore.Clear();
            await new AuthService().LogoutAsync();

            // Show login window
            var loginWindow = new LoginWindow();
            loginWindow.Show();

            // Close main window
            this.Close();
        }
    }
}
