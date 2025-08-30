using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityManagementApp.Auth
{
    public class Auth0Config
    {
        public static string Domain { get; set; } = "dev-u4t0zsbb0y0fio4y.us.auth0.com";
        public static string ClientId { get; set; } = "pIf7pZVZkAKKnpPeSbTiSZiSJzqVbwzm";
        public static string Audience { get; set; } = "https://city-management-api/";
    }
}
