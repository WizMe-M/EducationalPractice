using System;
using System.Windows;
using EducationalPracticeWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalPracticeWPF.Windows
{
    public partial class PostTableWindow
    {
        private readonly EducationalPracticeContext _database;

        public PostTableWindow()
        {
            InitializeComponent();
        }

        public PostTableWindow(EducationalPracticeContext context) : this()
        {
            _database = context;
            _database.Posts.Load();
            PostDataGrid.ItemsSource = _database.Posts.Local.ToBindingList();
        }

        private void ButtonAddPost_Click(object sender, RoutedEventArgs e)
        {
            var post = new Post
            {
                Naming = PostNaming.Text,
                Salary = decimal.Parse(PostSalary.Text)
            };
            _database.Posts.Add(post);
            _database.SaveChanges();
        }

        private void ButtonDeletePost_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Post)PostDataGrid.SelectedItem;
            _database.Posts.Remove(selected);
            _database.SaveChanges();
        }


        private void PostTableWindow_OnClosed(object? sender, EventArgs e)
        {
            PostDataGrid.CancelEdit();
            PostDataGrid.CancelEdit();
            Application.Current.MainWindow!.Show();
        }
    }
}