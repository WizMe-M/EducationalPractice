using System.Collections.Generic;

namespace EducationalPracticeWPF.Models
{
    public class Post
    {
        public Post()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Naming { get; set; }
        public decimal Salary { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
