﻿using System;
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

        public CustomerTableWindow()
        {
            InitializeComponent();
        }

        public CustomerTableWindow(DbContextOptions<EducationalPracticeContext> options) : this()
        {
            _database = new EducationalPracticeContext(options);
            _database.Customers.Load();
            CustomerDataGrid.ItemsSource = _database.Customers.Local.ToBindingList();
        }

        private async void ButtonAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer
            {
                FirstName = FirstNameTB.Text,
                LastName = LastNameTB.Text,
                Phone = PhoneTB.Text
            };

            _database.Customers.Add(customer);
            await _database.SaveChangesAsync();
        }

        private async void ButtonEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is not Customer selected) return;

            selected.FirstName = FirstNameTB.Text;
            selected.LastName = LastNameTB.Text;
            selected.Phone = PhoneTB.Text;

            _database.Customers.Update(selected);
            await _database.SaveChangesAsync();
            CustomerDataGrid.Items.Refresh();
        }

        private async void ButtonDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is not Customer selected) return;

            _database.Customers.Remove(selected);
            await _database.SaveChangesAsync();
        }

        private void CustomerDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is not Customer selected) return;

            FirstNameTB.Text = selected.FirstName;
            LastNameTB.Text = selected.LastName;
            PhoneTB.Text = selected.Phone;
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