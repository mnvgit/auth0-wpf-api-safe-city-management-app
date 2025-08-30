using CityManagementApp.Auth;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Input;

namespace CityManagementApp;
public class MainWindowViewModel
{
    private readonly HttpClient _client = new HttpClient
    {
        BaseAddress = new Uri("https://localhost:44322")
    };

    public ObservableCollection<CityTask> Tasks { get; set; } = new();
    public ObservableCollection<CityBuildProject> Projects { get; set; } = new();

    public string Username { get; set; } = SessionStore.UserName;

    public bool CanCreateProjects => SessionStore.Permissions.Contains("create:projects");
    public bool CanAcceptTasks => SessionStore.Permissions.Contains("update:tasks");
    public bool CanAcceptProjects => SessionStore.Permissions.Contains("update:projects");

    public ICommand CreateTaskCommand { get; }
    public ICommand CreateProjectCommand { get; }
    public ICommand AcceptTaskCommand { get; }
    public ICommand AcceptProjectCommand { get; }

    public MainWindowViewModel()
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionStore.AccessToken);

        CreateTaskCommand = new RelayCommand(async _ => await CreateTaskAsync());
        CreateProjectCommand = new RelayCommand(async _ => await CreateProjectAsync());
        AcceptTaskCommand = new RelayCommand(async t => await AcceptTaskAsync(t as CityTask));
        AcceptProjectCommand = new RelayCommand(async p => await AcceptProjectAsync(p as CityBuildProject));
    }

    public async Task LoadTasksDataAsync()
    {
        var taskJson = await _client.GetStringAsync("/tasks");
        Tasks.Clear();
        foreach (var t in JsonConvert.DeserializeObject<CityTask[]>(taskJson)!) Tasks.Add(t);
    }

    public async Task LoadProjectsDataAsync()
    {
        var projectJson = await _client.GetStringAsync("/projects");
        Projects.Clear();
        foreach (var p in JsonConvert.DeserializeObject<CityBuildProject[]>(projectJson)!) Projects.Add(p);
    }

    private async Task CreateTaskAsync()
    {
        var createWindow = new CreateTaskWindow();
        if (createWindow.ShowDialog() != true) return;

        var task = new CityTask
        {
            Task = createWindow.TaskDetails,
            Department = createWindow.Department
        };

        var content = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json");
        await _client.PostAsync("/task", content);
        await LoadTasksDataAsync();
    }

    private async Task CreateProjectAsync()
    {
        var createWindow = new CreateProjectWindow();
        if (createWindow.ShowDialog() != true) return;

        var content = new StringContent(JsonConvert.SerializeObject(new CityBuildProject { Details = createWindow.ProjectDetails, Budget = createWindow.Budget }),
                                        Encoding.UTF8, "application/json");
        await _client.PostAsync("/project", content);
        await LoadProjectsDataAsync();
    }

    private async Task AcceptTaskAsync(CityTask? task)
    {
        if (task == null) return;
        var result = await _client.PatchAsync($"/task/{task.Id}/accept", null);
        if (result.IsSuccessStatusCode)
            task.IsAccepted = true;
    }

    private async Task AcceptProjectAsync(CityBuildProject? project)
    {
        if (project == null) return;
        var result = await _client.PatchAsync($"/project/{project.Id}/accept", null);
        if (result.IsSuccessStatusCode)
            project.IsAccepted = true;
    }
}
