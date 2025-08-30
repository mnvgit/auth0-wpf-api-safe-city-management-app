using Auth0.OidcClient;
using Duende.IdentityModel.OidcClient;
using Duende.IdentityModel.OidcClient.Browser;
using System.Windows;

namespace CityManagementApp.Auth
{
    public class AuthService
    {
        private readonly Auth0Client client;

        public AuthService()
        {
            Auth0ClientOptions clientOptions = new Auth0ClientOptions
            {
                Domain = Auth0Config.Domain,
                ClientId = Auth0Config.ClientId,
                Scope = "openid profile email read:tasks create:tasks read:projects create:projects update:projects update:tasks"

            };
            client = new Auth0Client(clientOptions);
            clientOptions.PostLogoutRedirectUri = clientOptions.RedirectUri;

        }

        public async Task<LoginResult> LoginAsync()
        {
            try
            {
                return await client.LoginAsync(new { audience = Auth0Config.Audience });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}");
                return null!;
            }
        }

        public async Task<BrowserResultType> LogoutAsync()
        {
            try
            {
                return await client.LogoutAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Logout failed: {ex.Message}");
                return BrowserResultType.UnknownError;
            }
        }
    }
}
