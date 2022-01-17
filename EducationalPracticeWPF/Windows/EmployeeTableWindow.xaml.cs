using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using EducationalPracticeWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalPracticeWPF.Windows
{
    public partial class EmployeeTableWindow
    {
        private readonly EducationalPracticeContext _database;

        public EmployeeTableWindow()
        {
            InitializeComponent();
        }

        public EmployeeTableWindow(DbContextOptions<EducationalPracticeContext> options) : this()
        {
            _database = new EducationalPracticeContext(options);

            _database.Employees.Load();
            _database.Posts.Load();
            EmployeeDataGrid.ItemsSource = _database.Employees.Local.ToBindingList();
            Posts = _database.Posts.Local.ToBindingList();

            PostsCB.ItemsSource = Posts;
            PostsCB.DisplayMemberPath = nameof(Post.Naming);
            PostsCB.SelectedValuePath = nameof(Post.Id);
        }

        public BindingList<Post> Posts { get; }

        private void EmployeeTableWindow_OnClosed(object? sender, EventArgs e)
        {
            EmployeeDataGrid.CancelEdit();
            EmployeeDataGrid.CancelEdit();
            Application.Current.MainWindow!.Show();
        }

        private async void ButtonAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var employee = new Employee
            {
                FirstName = FirstNameTB.Text,
                LastName = LastNameTB.Text,
                MiddleName = MiddleNameTB.Text,
                PassportSeries = SeriesPassportTB.Text,
                PassportNumber = NumberPasswordTB.Text,
                Inn = InnTB.Text,
                PostId = (int)PostsCB.SelectedValue
            };

            _database.Employees.Add(employee);
            await _database.SaveChangesAsync();
        }

        private async void ButtonEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            await _database.SaveChangesAsync();
            if (EmployeeDataGrid.SelectedItem is not Employee edited) return;

            edited.FirstName = FirstNameTB.Text;
            edited.LastName = LastNameTB.Text;
            edited.MiddleName = MiddleNameTB.Text;
            edited.PassportSeries = SeriesPassportTB.Text;
            edited.PassportNumber = NumberPasswordTB.Text;
            edited.Inn = InnTB.Text;
            edited.PostId = (int)PostsCB.SelectedValue;

            _database.Employees.Update(edited);
            await _database.SaveChangesAsync();
            EmployeeDataGrid.Items.Refresh();
        }

        private async void ButtonDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if(EmployeeDataGrid.SelectedItem is not Employee employee) return;
            
            _database.Employees.Remove(employee);
            await _database.SaveChangesAsync();
        }

        private void EmployeeDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem is not Employee selected) return;

            FirstNameTB.Text = selected.FirstName;
            LastNameTB.Text = selected.LastName;
            MiddleNameTB.Text = selected.MiddleName;
            SeriesPassportTB.Text = selected.PassportSeries;
            NumberPasswordTB.Text = selected.PassportNumber;
            InnTB.Text = selected.Inn;
            PostsCB.SelectedItem = selected.Post;
        }
    }
}