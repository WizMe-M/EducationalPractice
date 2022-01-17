using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using EducationalPracticeWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalPracticeWPF.Windows
{
    public partial class ProductTableWindow
    {
        private readonly EducationalPracticeContext _database;

        public ProductTableWindow(DbContextOptions<EducationalPracticeContext> options)
        {
            InitializeComponent();
            
            _database = new EducationalPracticeContext(options);
            _database.Products.Load();
            _database.Colors.Load();
            _database.ProductTypes.Load();
            
            ProductDataGrid.ItemsSource = _database.Products.Local.ToBindingList();
            ColorsCB.ItemsSource = _database.Colors.Local.ToBindingList();
            ColorsCB.DisplayMemberPath = nameof(Color.Naming);
            ProductTypesCB.ItemsSource = _database.ProductTypes.Local.ToBindingList();
            ProductTypesCB.DisplayMemberPath = nameof(ProductType.Naming);
        }

        private async void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            var product = new Product
            {
                Naming = NamingTB.Text,
                Price = decimal.Parse(PriceTB.Text),
                Color = (Color)ColorsCB.SelectedItem,
                ProductType = (ProductType)ProductTypesCB.SelectedItem
            };

            _database.Products.Add(product);
            await _database.SaveChangesAsync();
        }

        private async void ButtonEditProduct_Click(object sender, RoutedEventArgs e)
        {
            if(ProductDataGrid.SelectedItem is not Product selected) return;

            selected.Naming = NamingTB.Text;
            selected.Price = decimal.Parse(PriceTB.Text);
            selected.Color = (Color)ColorsCB.SelectedItem;
            selected.ProductType = (ProductType)ProductTypesCB.SelectedItem;

            _database.Products.Update(selected);
            await _database.SaveChangesAsync();
            ProductDataGrid.Items.Refresh();
        }

        private async void ButtonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if(ProductDataGrid.SelectedItem is not Product selected) return;
            
            _database.Products.Remove(selected);
            await _database.SaveChangesAsync();
        }

        private void ProductDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductDataGrid.SelectedItem is not Product selected) return;

            NamingTB.Text = selected.Naming;
            PriceTB.Text = selected.Price.ToString();
            ColorsCB.SelectedItem = selected.Color;
            ProductTypesCB.SelectedItem = selected.ProductType;
        }

        private void ProductTableWindow_OnClosed(object? sender, EventArgs e)
        {
            ProductDataGrid.CancelEdit();
            ProductDataGrid.CancelEdit();
            Application.Current.MainWindow!.Show();
        }
    }
}