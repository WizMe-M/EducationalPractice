using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EducationalPracticeWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalPracticeWPF.Windows
{
    public partial class ColorTableWindow
    {
        private readonly EducationalPracticeContext _database;

        public ColorTableWindow(DbContextOptions<EducationalPracticeContext> options)
        {
            InitializeComponent();
            _database = new EducationalPracticeContext(options);
            _database.Colors.Load();
            ColorDataGrid.ItemsSource = _database.Colors.Local.ToBindingList();
        }


        private async void ButtonAddColor_Click(object sender, RoutedEventArgs e)
        {
            var color = new Color
            {
                Naming = ColorNamingTB.Text
            };
            _database.Colors.Add(color);
            await _database.SaveChangesAsync();
        }

        private async void ButtonEditColor_Click(object sender, RoutedEventArgs e)
        {
            if (ColorDataGrid.SelectedItem is not Color selected) return;

            selected.Naming = ColorNamingTB.Text;

            _database.Colors.Update(selected);
            await _database.SaveChangesAsync();
            ColorDataGrid.Items.Refresh();
        }

        private async void ButtonDeleteColor_Click(object sender, RoutedEventArgs e)
        {
            if (ColorDataGrid.SelectedItem is not Color selected) return;

            await _database.Products.LoadAsync();
            if (selected.Products.Count != 0)
            {
                MessageBox.Show(
                    "Невозможно удалить выбранный цвет, поскольку у него есть зависимые товары",
                    "Удаление невозможно", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            _database.Colors.Remove(selected);
            await _database.SaveChangesAsync();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchText = SearchTB.Text;
            var filtered = new BindingList<Color>();
            var colors = _database.Colors.Where(c => c.Naming.Contains(searchText));
            
            foreach (var color in colors)
                filtered.Add(color);

            ColorDataGrid.ItemsSource = filtered;
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            ColorDataGrid.ItemsSource = _database.Colors.Local.ToBindingList();
        }

        private void ColorDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ColorDataGrid.SelectedItem is not Color selected) return;

            ColorNamingTB.Text = selected.Naming;
        }

        private void ColorTableWindow_OnClosed(object? sender, EventArgs e)
        {
            ColorDataGrid.CancelEdit();
            ColorDataGrid.CancelEdit();
            Application.Current.MainWindow!.Show();
        }
    }
}