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

        public EmployeeTableWindow(DbContextOptions<EducationalPracticeContext> options)
        {
            InitializeComponent();
            
            _database = new EducationalPracticeContext(options);
            _database.Employees.Load();
            _database.Posts.Load();
            
            EmployeeDataGrid.ItemsSource = _database.Employees.Local.ToBindingList();
            PostsCB.ItemsSource = _database.Posts.Local.ToBindingList();
            PostsCB.DisplayMemberPath = nameof(Post.Naming);
            PostsCB.SelectedValuePath = nameof(Post.Id);
        }
        
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
                Post = (Post)PostsCB.SelectedItem
            };

            _database.Employees.Add(employee);
            await _database.SaveChangesAsync();
        }

        private async void ButtonEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            await _database.SaveChangesAsync();
            if (EmployeeDataGrid.SelectedItem is not Employee selected) return;

            selected.FirstName = FirstNameTB.Text;
            selected.LastName = LastNameTB.Text;
            selected.MiddleName = MiddleNameTB.Text;
            selected.PassportSeries = SeriesPassportTB.Text;
            selected.PassportNumber = NumberPasswordTB.Text;
            selected.Inn = InnTB.Text;
            selected.Post = (Post)PostsCB.SelectedItem;

            _database.Employees.Update(selected);
            await _database.SaveChangesAsync();
            EmployeeDataGrid.Items.Refresh();
        }

        private async void ButtonDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if(EmployeeDataGrid.SelectedItem is not Employee selected) return;
            
            _database.Employees.Remove(selected);
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