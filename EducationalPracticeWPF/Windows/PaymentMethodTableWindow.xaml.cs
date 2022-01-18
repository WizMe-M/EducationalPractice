using System;
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
            if(PaymentMethodDataGrid.SelectedItem is not PaymentMethod selected) return;

            selected.Naming = NamingTB.Text;
            _database.PaymentMethods.Update(selected);
            await _database.SaveChangesAsync();
        }

        private async void ButtonDeletePaymentMethod_Click(object sender, RoutedEventArgs e)
        {
            if(PaymentMethodDataGrid.SelectedItem is not PaymentMethod selected) return;

            _database.PaymentMethods.Remove(selected);
            await _database.SaveChangesAsync();
        }

        private void PaymentMethodDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(PaymentMethodDataGrid.SelectedItem is not PaymentMethod selected) return;

            NamingTB.Text = selected.Naming;
        }

        private void PaymentMethodTableWindow_OnClosed(object? sender, EventArgs e)
        {
            PaymentMethodDataGrid.CancelEdit();
            PaymentMethodDataGrid.CancelEdit();
            Application.Current.MainWindow!.Show();
        }
    }
}