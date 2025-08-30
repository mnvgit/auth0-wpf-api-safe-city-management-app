using Duende.IdentityModel.OidcClient.Browser;
using System.Diagnostics;

namespace CityManagementApp.Auth
{
    public class WpfAuthBrowser : IBrowser
    {
        public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
        {
            var psi = new ProcessStartInfo
            {
                FileName = options.StartUrl,
                UseShellExecute = false
            };
            Process.Start(psi);
            return await Task.FromResult(new BrowserResult { ResultType = BrowserResultType.Success, Response = options.EndUrl });
        }
    }
}
