namespace CityManagementApp.Auth
{
    public static class SessionStore
    {
        public static string? AccessToken { get; set; }
        public static string? IdToken { get; set; }
        public static string? UserName { get; set; }
        public static HashSet<string> Permissions { get; set; } = new();

        // Clears all stored session data
        public static void Clear()
        {
            AccessToken = null;
            IdToken = null;
            UserName = null;
            Permissions.Clear();
        }
    }
}
