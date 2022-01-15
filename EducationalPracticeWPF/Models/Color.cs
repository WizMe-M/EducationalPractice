using System.Collections.Generic;

#nullable disable

namespace EducationalPracticeWPF.Models
{
    public class Color
    {
        public Color()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Naming { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
