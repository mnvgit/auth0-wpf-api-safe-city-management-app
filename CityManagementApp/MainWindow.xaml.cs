using CityManagementApp.Auth;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CityManagementApp
{
    public partial class MainWindow : Window
    {
        private readonly string _apiBaseUrl = "https://localhost:44322";
        private readonly HttpClient _httpClient;

        public ObservableCollection<CityTask> Tasks { get; set; } = new();
        public ObservableCollection<CityBuildProject> Projects { get; set; } = new();

        public bool CanAcceptTasks => SessionStore.Permissions.Contains("update:tasks");
        public bool CanAcceptProjects => SessionStore.Permissions.Contains("update:projects");

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionStore.AccessToken);

            Loaded += MainWindow_Loaded;

            CreateTaskButton.Click += async (_, __) => await CreateTaskAsync();
            CreateProjectButton.Click += async (_, __) => await CreateProjectAsync();
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Enable/disable create buttons
            CreateTaskButton.IsEnabled = SessionStore.Permissions.Contains("create:tasks");
            CreateProjectButton.IsEnabled = SessionStore.Permissions.Contains("create:projects");

            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var taskJson = await _httpClient.GetStringAsync($"{_apiBaseUrl}/tasks");
            var tasks = JsonConvert.DeserializeObject<List<CityTask>>(taskJson)!;
            Tasks.Clear();
            foreach (var t in tasks)
                Tasks.Add(t);

            var projectJson = await _httpClient.GetStringAsync($"{_apiBaseUrl}/projects");
            var projects = JsonConvert.DeserializeObject<List<CityBuildProject>>(projectJson)!;
            Projects.Clear();
            foreach (var p in projects)
                Projects.Add(p);
        }

        private async void AcceptTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is CityTask task)
            {
                await _httpClient.PatchAsync($"{_apiBaseUrl}/task/{task.Id}/accept", null);

                task.IsAccepted = true;
                TasksList.Items.Refresh();
            }
        }

        private async void AcceptProjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is CityBuildProject project)
            {
                await _httpClient.PatchAsync($"{_apiBaseUrl}/project/{project.Id}/accept", null);

                project.IsAccepted = true;
                ProjectsList.Items.Refresh();
            }
        }

        private async Task CreateTaskAsync()
        {
            var details = Microsoft.VisualBasic.Interaction.InputBox("Enter task details:", "Create Task", "");
            if (string.IsNullOrWhiteSpace(details)) return;


            var content = new StringContent(JsonConvert.SerializeObject(new CityTask { Details = details }),
                                            Encoding.UTF8, "application/json");
            await _httpClient.PostAsync($"{_apiBaseUrl}/task", content);
            await LoadDataAsync();
        }

        private async Task CreateProjectAsync()
        {
            var details = Microsoft.VisualBasic.Interaction.InputBox("Enter project details:", "Create Project", "");
            if (string.IsNullOrWhiteSpace(details)) return;

            var content = new StringContent(JsonConvert.SerializeObject(new CityBuildProject { Details = details }),
                                            Encoding.UTF8, "application/json");
            await _httpClient.PostAsync($"{_apiBaseUrl}/project", content);
            await LoadDataAsync();
        }
    }
}
