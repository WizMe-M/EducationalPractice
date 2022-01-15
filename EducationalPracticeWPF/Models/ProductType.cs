using System;
using System.Collections.Generic;

#nullable disable

namespace EducationalPracticeWPF
{
    public partial class ProductType
    {
        public ProductType()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Naming { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
