using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EducationalPracticeWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalPracticeWPF.Windows
{
    public partial class PaymentMethodTableWindow
    {
        private readonly EducationalPracticeContext _database;

        public PaymentMethodTableWindow(DbContextOptions<EducationalPracticeContext> options)
        {
            InitializeComponent();
            _database = new EducationalPracticeContext(options);
            _database.PaymentMethods.Load();
            PaymentMethodDataGrid.ItemsSource = _database.PaymentMethods.Local.ToBindingList();
        }

        private async void ButtonAddPaymentMethod_Click(object sender, RoutedEventArgs e)
        {
            var method = new PaymentMethod
            {
                Naming = NamingTB.Text
            };
            _database.PaymentMethods.Add(method);
            await _database.SaveChangesAsync();
        }

        private async void ButtonEditPaymentMethod_Click(object sender, RoutedEventArgs e)
        {
            if (PaymentMethodDataGrid.SelectedItem is not PaymentMethod selected) return;

            selected.Naming = NamingTB.Text;
            _database.PaymentMethods.Update(selected);
            await _database.SaveChangesAsync();
        }

        private async void ButtonDeletePaymentMethod_Click(object sender, RoutedEventArgs e)
        {
            if (PaymentMethodDataGrid.SelectedItem is not PaymentMethod selected) return;

            await _database.Receipts.LoadAsync();
            if (selected.Receipts.Count != 0)
            {
                MessageBox.Show(
                    "Невозможно удалить выбранный способ оплаты, поскольку у него есть зависимые чеки",
                    "Удаление невозможно", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            _database.PaymentMethods.Remove(selected);
            await _database.SaveChangesAsync();
        }

        private void PaymentMethodDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PaymentMethodDataGrid.SelectedItem is not PaymentMethod selected) return;

            NamingTB.Text = selected.Naming;
        }

        private void PaymentMethodTableWindow_OnClosed(object? sender, EventArgs e)
        {
            PaymentMethodDataGrid.CancelEdit();
            PaymentMethodDataGrid.CancelEdit();
            Application.Current.MainWindow!.Show();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchText = SearchTB.Text;
            var filtered = new BindingList<PaymentMethod>();
            var paymentMethods = _database.PaymentMethods.Where(pm => pm.Naming.Contains(searchText));

            foreach (var method in paymentMethods)
                filtered.Add(method);

            PaymentMethodDataGrid.ItemsSource = filtered;
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            PaymentMethodDataGrid.ItemsSource = _database.PaymentMethods.Local.ToBindingList();
        }
    }
}