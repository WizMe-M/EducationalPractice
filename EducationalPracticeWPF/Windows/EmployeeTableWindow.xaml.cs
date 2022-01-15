using System;
using System.ComponentModel;
using System.Windows;
using EducationalPracticeWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalPracticeWPF.Windows
{
    public partial class EmployeeTableWindow : Window
    {
        private readonly EducationalPracticeContext _database;
        public EmployeeTableWindow()
        {
            InitializeComponent();
        }

        public EmployeeTableWindow(EducationalPracticeContext context) : this()
        {
            _database = context;
            _database.Employees.Load();
            _database.Posts.Load();
            EmployeeDataGrid.ItemsSource = _database.Employees.Local.ToBindingList();
            Posts = _database.Posts.Local.ToBindingList();
        }

        public BindingList<Post> Posts { get; }

        private void EmployeeTableWindow_OnClosed(object? sender, EventArgs e)
        {
            Application.Current.MainWindow!.Show();
        }
    }
}