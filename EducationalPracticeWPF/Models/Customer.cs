using System.Collections.Generic;

namespace EducationalPracticeWPF.Models
{
    public class Customer
    {
        public Customer()
        {
            Receipts = new HashSet<Receipt>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
