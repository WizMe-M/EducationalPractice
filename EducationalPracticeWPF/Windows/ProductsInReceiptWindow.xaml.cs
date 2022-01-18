using System.Linq;
using System.Windows;
using EducationalPracticeWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalPracticeWPF.Windows
{
    public partial class ProductsInReceiptWindow
    {
        private readonly EducationalPracticeContext _database;
        private readonly Receipt _receipt;
        public ProductsInReceiptWindow(EducationalPracticeContext context, Receipt selected)
        {
            InitializeComponent();
            _database = context;
            _receipt = selected;
            _database.Products.Load();
            _database.Receipts.Load();
            _database.Colors.Load();
            _database.ProductTypes.Load();
            _database.ProductsInReceipts.Load();
            ProductDataGrid.ItemsSource = _database.Products.Local.ToBindingList();
        }

        private async void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if(ProductDataGrid.SelectedItem is not Product selected) return;

            var product = new ProductsInReceipt
            {
                Product = selected,
                Receipt = _receipt,
                ProductCount = int.Parse(ProductCountTB.Text)
            };
            _database.ProductsInReceipts.Add(product);
            await _database.SaveChangesAsync();
        }

        private async void ButtonSaveCount_Click(object sender, RoutedEventArgs e)
        {
            if(ProductDataGrid.SelectedItem is not Product selected) return;

            var productInReceipt = _database.ProductsInReceipts
                    .FirstOrDefault(p => p.Product == selected && p.Receipt == _receipt);

            if (productInReceipt is null) return;

            productInReceipt.ProductCount = int.Parse(ProductCountTB.Text);
            _database.ProductsInReceipts.Update(productInReceipt);
            await _database.SaveChangesAsync();
        }

        private async void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if(ProductDataGrid.SelectedItem is not Product selected) return;

            var productInReceipt = _database.ProductsInReceipts
                .FirstOrDefault(p => p.Product == selected && p.Receipt == _receipt);

            if (productInReceipt is null) return;

            _database.ProductsInReceipts.Remove(productInReceipt);
            await _database.SaveChangesAsync();
        }

        private void ButtonReturn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}