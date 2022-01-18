using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EducationalPracticeWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalPracticeWPF.Windows
{
    public partial class ProductTypeTableWindow
    {
        private readonly EducationalPracticeContext _database;

        public ProductTypeTableWindow(DbContextOptions<EducationalPracticeContext> options)
        {
            InitializeComponent();
            _database = new EducationalPracticeContext(options);
            _database.ProductTypes.Load();
            ProductTypeDataGrid.ItemsSource = _database.ProductTypes.Local.ToBindingList();
        }

        private async void ButtonAddProductType_Click(object sender, RoutedEventArgs e)
        {
            var productType = new ProductType
            {
                Naming = ProductTypeNamingTB.Text
            };

            _database.ProductTypes.Add(productType);
            await _database.SaveChangesAsync();
        }

        private async void ButtonEditProductType_Click(object sender, RoutedEventArgs e)
        {
            if (ProductTypeDataGrid.SelectedItem is not ProductType selected) return;

            selected.Naming = ProductTypeNamingTB.Text;
            _database.ProductTypes.Update(selected);
            await _database.SaveChangesAsync();
            ProductTypeDataGrid.Items.Refresh();
        }

        private async void ButtonDeleteProductType_Click(object sender, RoutedEventArgs e)
        {
            if (ProductTypeDataGrid.SelectedItem is not ProductType selected) return;

            await _database.Posts.LoadAsync();
            if (selected.Products.Count != 0)
            {
                MessageBox.Show(
                    "Невозможно удалить выбранный вид товара, поскольку у него есть зависимые товары",
                    "Удаление невозможно", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            _database.ProductTypes.Remove(selected);
            await _database.SaveChangesAsync();
        }

        private void ProductTypeDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductTypeDataGrid.SelectedItem is not ProductType selected) return;

            ProductTypeNamingTB.Text = selected.Naming;
        }

        private void ProductTypeTableWindow_OnClosed(object? sender, EventArgs e)
        {
            ProductTypeDataGrid.CancelEdit();
            ProductTypeDataGrid.CancelEdit();
            Application.Current.MainWindow!.Show();
        }
        
        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchText = SearchTB.Text;
            var filtered = new BindingList<ProductType>();
            var productTypes = _database.ProductTypes.Where(p => p.Naming.Contains(searchText));

            foreach (var type in productTypes)
                filtered.Add(type);

            ProductTypeDataGrid.ItemsSource = filtered;
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            ProductTypeDataGrid.ItemsSource = _database.ProductTypes.Local.ToBindingList();
        }
    }
}