using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EducationalPracticeWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalPracticeWPF.Windows
{
    public partial class ReceiptTableWindow
    {
        private readonly EducationalPracticeContext _database;
        private readonly BindingList<Receipt> _receipts;

        public ReceiptTableWindow(DbContextOptions<EducationalPracticeContext> options)
        {
            InitializeComponent();
            _database = new EducationalPracticeContext(options);
            _database.Receipts.Load();
            _database.ProductsInReceipts.Load();
            _database.Customers.Load();
            _database.Employees.Load();
            _database.PaymentMethods.Load();

            _receipts = _database.Receipts.Local.ToBindingList();
            ReceiptDataGrid.ItemsSource = _receipts;
            CustomersCB.ItemsSource = _database.Customers.Local.ToBindingList();
            EmployeesCB.ItemsSource = _database.Employees.Local.ToBindingList();
            PaymentMethodsCB.ItemsSource = _database.PaymentMethods.Local.ToBindingList();
            PaymentMethodsCB.DisplayMemberPath = nameof(PaymentMethod.Naming);
        }

        private async void ButtonAddReceipt_Click(object sender, RoutedEventArgs e)
        {
            var receipt = new Receipt
            {
                RegistrationDate = RegistrationDatePicker.SelectedDate ?? DateTime.Today,
                Customer = (Customer)CustomersCB.SelectedItem,
                Employee = (Employee)EmployeesCB.SelectedItem,
                PaymentMethod = (PaymentMethod)PaymentMethodsCB.SelectedItem,
                TotalSum = 0
            };

            _database.Receipts.Add(receipt);
            await _database.SaveChangesAsync();
        }

        private async void ButtonEditReceipt_Click(object sender, RoutedEventArgs e)
        {
            if (ReceiptDataGrid.SelectedItem is not Receipt selected) return;

            selected.RegistrationDate = RegistrationDatePicker.SelectedDate!.Value;
            selected.Customer = (Customer)CustomersCB.SelectedItem;
            selected.Employee = (Employee)EmployeesCB.SelectedItem;
            selected.PaymentMethod = (PaymentMethod)PaymentMethodsCB.SelectedItem;

            _database.Receipts.Update(selected);
            await _database.SaveChangesAsync();
            ReceiptDataGrid.Items.Refresh();
        }

        private async void ButtonDeleteReceipt_Click(object sender, RoutedEventArgs e)
        {
            if (ReceiptDataGrid.SelectedItem is not Receipt selected) return;

            if (selected.ProductsInReceipts is not null)
            {
                foreach (var productsInReceipt in _database.ProductsInReceipts)
                {
                    if (productsInReceipt.Receipt != selected) continue;
                    _database.ProductsInReceipts.Remove(productsInReceipt);
                }

                await _database.SaveChangesAsync();
            }

            _database.Receipts.Remove(selected);
            await _database.SaveChangesAsync();
        }

        private async void ButtonAddProductsInReceipt_Click(object sender, RoutedEventArgs e)
        {
            if (ReceiptDataGrid.SelectedItem is not Receipt selected) return;

            var addProductsWindow = new ProductsInReceiptWindow(_database, selected);
            if (addProductsWindow.ShowDialog() == true)
            {
                selected.TotalSum = 0;
                foreach (var productsInReceipt in selected.ProductsInReceipts)
                    selected.TotalSum += productsInReceipt.ProductCount * productsInReceipt.Product.Price;

                await _database.SaveChangesAsync();
                ReceiptDataGrid.Items.Refresh();
            }
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchText = SearchTB.Text;
            var filtered = new BindingList<Receipt>();
            var receipts = _database.Receipts
                .Where(r => r.RegistrationDate.ToString().Contains(searchText)
                            || r.TotalSum.ToString() == searchText
                            || r.Employee.Inn.Contains(searchText)
                            || r.Customer.Phone.Contains(searchText)
                            || r.PaymentMethod.Naming.Contains(searchText));
            
            foreach (var receipt in receipts)
                filtered.Add(receipt);

            ReceiptDataGrid.ItemsSource = filtered;
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            ReceiptDataGrid.ItemsSource = _database.Receipts.Local.ToBindingList();
        }

        private void ReceiptDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReceiptDataGrid.SelectedItem is not Receipt selected) return;

            RegistrationDatePicker.SelectedDate = selected.RegistrationDate;
            CustomersCB.SelectedItem = selected.Customer;
            EmployeesCB.SelectedItem = selected.Employee;
            PaymentMethodsCB.SelectedItem = selected.PaymentMethod;
        }

        private void ReceiptTableWindow_OnClosed(object? sender, EventArgs e)
        {
            ReceiptDataGrid.CancelEdit();
            ReceiptDataGrid.CancelEdit();
            Application.Current.MainWindow!.Show();
        }
    }
}