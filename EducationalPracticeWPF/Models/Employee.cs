using System.Collections.Generic;

namespace EducationalPracticeWPF.Models
{
    public class Employee
    {
        public Employee()
        {
            Receipts = new HashSet<Receipt>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string Inn { get; set; }
        public int PostId { get; set; }

        public Post Post { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
    }
}
