using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        public PostTableWindow(DbContextOptions<EducationalPracticeContext> options) : this()
        {
            _database = new EducationalPracticeContext(options);
            _database.Posts.Load();
            PostDataGrid.ItemsSource = _database.Posts.Local.ToBindingList();
        }

        private async void ButtonAddPost_Click(object sender, RoutedEventArgs e)
        {
            var post = new Post
            {
                Naming = PostNaming.Text,
                Salary = decimal.Parse(PostSalary.Text)
            };

            _database.Posts.Add(post);
            await _database.SaveChangesAsync();
        }

        private async void ButtonEditPost_Click(object sender, RoutedEventArgs e)
        {
            if (PostDataGrid.SelectedItem is not Post selected) return;

            selected.Naming = PostNaming.Text;
            selected.Salary = decimal.Parse(PostSalary.Text);

            _database.Posts.Update(selected);
            await _database.SaveChangesAsync();
            PostDataGrid.Items.Refresh();
        }

        private async void ButtonDeletePost_Click(object sender, RoutedEventArgs e)
        {
            if (PostDataGrid.SelectedItem is not Post selected) return;

            _database.Posts.Remove(selected);
            await _database.SaveChangesAsync();
        }

        private void PostDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PostDataGrid.SelectedItem is not Post selected) return;

            PostNaming.Text = selected.Naming;
            PostSalary.Text = selected.Salary.ToString();
        }

        private void PostTableWindow_OnClosed(object? sender, EventArgs e)
        {
            PostDataGrid.CancelEdit();
            PostDataGrid.CancelEdit();
            Application.Current.MainWindow!.Show();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchText = SearchTB.Text;
            var filtered = new BindingList<Post>();
            var posts = _database.Posts.Where(p => p.Naming.Contains(searchText)
                                                    || p.Salary.ToString() == searchText);

            foreach (var post in posts)
                filtered.Add(post);

            PostDataGrid.ItemsSource = filtered;
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            PostDataGrid.ItemsSource = _database.Posts.Local.ToBindingList();
        }
    }
}