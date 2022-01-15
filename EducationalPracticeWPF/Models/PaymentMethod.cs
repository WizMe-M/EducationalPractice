using System;
using System.Collections.Generic;

#nullable disable

namespace EducationalPracticeWPF
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Receipts = new HashSet<Receipt>();
        }

        public int Id { get; set; }
        public string Naming { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
