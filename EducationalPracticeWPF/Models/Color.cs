using System.Collections.Generic;

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

        public ICollection<Product> Products { get; set; }
    }
}
