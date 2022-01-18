using System.Collections.Generic;

#nullable disable

namespace EducationalPracticeWPF.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Receipts = new HashSet<Receipt>();
        }

        public int Id { get; set; }
        public string Naming { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
