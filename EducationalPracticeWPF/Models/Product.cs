using System.Collections.Generic;

namespace EducationalPracticeWPF.Models
{
    public class Product
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

        public Color Color { get; set; }
        public ProductType ProductType { get; set; }
        public ICollection<ProductsInReceipt> ProductsInReceipts { get; set; }
    }
}
