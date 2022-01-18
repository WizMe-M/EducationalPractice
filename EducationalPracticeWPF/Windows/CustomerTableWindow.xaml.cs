using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EducationalPracticeWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalPracticeWPF.Windows
{
    public partial class CustomerTableWindow
    {
        private readonly EducationalPracticeContext _database;

        public CustomerTableWindow(DbContextOptions<EducationalPracticeContext> options)
        {
            InitializeComponent();
            _database = new EducationalPracticeContext(options);
            _database.Customers.Load();
            
            CustomerDataGrid.ItemsSource = _database.Customers.Local.ToBindingList();
        }

        private async void ButtonAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer
            {
                FirstName = CustomerFirstNameTb.Text,
                LastName = CustomerLastNameTb.Text,
                Phone = CustomerPhoneTb.Text
            };

            _database.Customers.Add(customer);
            await _database.SaveChangesAsync();
        }

        private async void ButtonEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is not Customer selected) return;

            selected.FirstName = CustomerFirstNameTb.Text;
            selected.LastName = CustomerLastNameTb.Text;
            selected.Phone = CustomerPhoneTb.Text;

            _database.Customers.Update(selected);
            await _database.SaveChangesAsync();
            CustomerDataGrid.Items.Refresh();
        }

        private async void ButtonDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is not Customer selected) return;

            await _database.Receipts.LoadAsync();
            if (selected.Receipts.Count != 0)
            {
                MessageBox.Show(
                    "Невозможно удалить выбранного покупателя, поскольку у него есть зависимые чеки",
                    "Удаление невозможно", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            _database.Customers.Remove(selected);
            await _database.SaveChangesAsync();
        }

        private void CustomerDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is not Customer selected) return;

            CustomerFirstNameTb.Text = selected.FirstName;
            CustomerLastNameTb.Text = selected.LastName;
            CustomerPhoneTb.Text = selected.Phone;
        }

        private void CustomerTableWindow_OnClosed(object? sender, EventArgs e)
        {
            CustomerDataGrid.CancelEdit();
            CustomerDataGrid.CancelEdit();
            Application.Current.MainWindow!.Show();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchText = SearchTB.Text;
            var filtered = new BindingList<Customer>();
            var customers = _database.Customers.Where(с => с.FirstName.Contains(searchText)
                                                          || с.LastName.Contains(searchText)
                                                          || с.Phone.Contains(searchText));

            foreach (var customer in customers)
                filtered.Add(customer);

            CustomerDataGrid.ItemsSource = filtered;
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            CustomerDataGrid.ItemsSource = _database.Customers.Local.ToBindingList();
        }
    }
}