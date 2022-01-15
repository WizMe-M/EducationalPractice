using System;
using System.Collections.Generic;
using EducationalPracticeWPF.Models;

#nullable disable

namespace EducationalPracticeWPF
{
    public partial class Product
    {
        public Product()
        {
            ProductsInReceipts = new HashSet<ProductsInReceipt>();
        }

        public int Id { get; set; }
        public string Naming { get; set; }
        public decimal Price { get; set; }
        public int ColorId { get; set; }
        public int ProductTypeId { get; set; }

        public virtual Color Color { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<ProductsInReceipt> ProductsInReceipts { get; set; }
    }
}
