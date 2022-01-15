using System;
using System.Collections.Generic;
using EducationalPracticeWPF.Models;

#nullable disable

namespace EducationalPracticeWPF
{
    public partial class Receipt
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

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual ICollection<ProductsInReceipt> ProductsInReceipts { get; set; }
    }
}
