using System.Windows;

namespace CityManagementApp
{
    public partial class CreateTaskWindow : Window
    {
        public string TaskDetails { get; set; } = string.Empty;
        public CityDepartment Department { get; private set; } = CityDepartment.Garden;

        public CreateTaskWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            TaskDetails = DetailsTextBox.Text;
            Department = (CityDepartment)DepartmentComboBox.SelectedIndex;
            DialogResult = true;
            Close();
        }
    }

}
