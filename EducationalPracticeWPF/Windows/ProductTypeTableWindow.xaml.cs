using System;
using System.Windows;
using System.Windows.Controls;
using EducationalPracticeWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalPracticeWPF.Windows
{
    public partial class ProductTypeTableWindow
    {
        private readonly EducationalPracticeContext _database;

        public ProductTypeTableWindow()
        {
            InitializeComponent();
        }

        public ProductTypeTableWindow(DbContextOptions<EducationalPracticeContext> options) : this()
        {
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
    }
}