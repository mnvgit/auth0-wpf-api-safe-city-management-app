using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace CityManagementApp
{
    public partial class CreateProjectWindow : Window
    {
        public string ProjectDetails { get; private set; } = string.Empty;
        public decimal Budget { get; private set; } = 0;

        public CreateProjectWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectDetails = DetailsTextBox.Text;
            Budget = decimal.Parse(BudgetTextBox.Text);
            DialogResult = true;
            Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }

}
