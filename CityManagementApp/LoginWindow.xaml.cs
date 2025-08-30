using CityManagementApp.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Windows;

namespace CityManagementApp
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            var result = await new AuthService().LoginAsync();

            if (result.IsError)
            {
                MessageBox.Show($"Login error: {result.Error}");
                return;
            }

            // Extract permissions from access token
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(result.AccessToken);

            // Save tokens globally (for API calls)
            SessionStore.AccessToken = result.AccessToken;
            SessionStore.IdToken = result.IdentityToken;
            SessionStore.UserName = result.User.FindFirst("name")?.Value ?? "Unknown";
            SessionStore.Permissions = jwt.Claims.Where(c => c.Type == "permissions").Select(c => c.Value).ToHashSet();

            var main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
