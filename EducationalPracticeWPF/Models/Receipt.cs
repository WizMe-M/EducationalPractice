using System;
using System.Collections.Generic;

#nullable disable

namespace EducationalPracticeWPF.Models
{
    public class Receipt
    {
        public Receipt()
        {
            ProductsInReceipts = new HashSet<ProductsInReceipt>();
        }

        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public decimal TotalSum { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int PaymentMethodId { get; set; }

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public ICollection<ProductsInReceipt> ProductsInReceipts { get; set; }
    }
}
