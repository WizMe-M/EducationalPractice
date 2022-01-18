using System.Windows;
using EducationalPracticeWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalPracticeWPF.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly DbContextOptions<EducationalPracticeContext> _options;
        public MainWindow()
        {
            InitializeComponent();
            _options = DatabaseManager.GetOptions();
        }

        private void ButtonEmployee_Click(object sender, RoutedEventArgs e)
        {
            var employees = new EmployeeTableWindow(_options);
            employees.Show();
            Hide();
        }


        private void ButtonPost_Click(object sender, RoutedEventArgs e)
        {
            var posts = new PostTableWindow(_options);
            posts.Show();
            Hide();
        }

        private void ButtonCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customers = new CustomerTableWindow(_options);
            customers.Show();
            Hide();
        }

        private void ButtonProduct_Click(object sender, RoutedEventArgs e)
        {
            var products = new ProductTableWindow(_options);
            products.Show();
            Hide();
        }

        private void ButtonProductType_Click(object sender, RoutedEventArgs e)
        {
            var productTypes = new ProductTypeTableWindow(_options);
            productTypes.Show();
            Hide();
        }

        private void ButtonColor_Click(object sender, RoutedEventArgs e)
        {
            var colors = new ColorTableWindow(_options);
            colors.Show();
            Hide();
        }

        private void ButtonPaymentMethod_Click(object sender, RoutedEventArgs e)
        {
            var paymentTypes = new PaymentMethodTableWindow(_options);
            paymentTypes.Show();
            Hide();
        }

        private void ButtonReceipt_Click(object sender, RoutedEventArgs e)
        {
            var products = new ReceiptTableWindow(_options);
            products.Show();
            Hide();
        }
    }
}