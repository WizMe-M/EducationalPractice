using System.Windows;
using EducationalPracticeWPF.Models;

namespace EducationalPracticeWPF.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private EducationalPracticeContext _database = null!; 
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _database = DatabaseManager.InitDatabase();
        }

        private void ButtonEmployee_Click(object sender, RoutedEventArgs e)
        {
            // var employees = new EmployeeTableWindow(_database);
            // employees.Show();
            // Hide();
        }


        private void ButtonPost_Click(object sender, RoutedEventArgs e)
        {
            var posts = new PostTableWindow(_database);
            posts.Show();
            Hide();
        }
    }
}