using System.Configuration;
using EducationalPracticeWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalPracticeWPF
{
    public class DatabaseManager
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public static EducationalPracticeContext InitDatabase()
        {
            var optionsBuilder = new DbContextOptionsBuilder<EducationalPracticeContext>();
            var options = optionsBuilder.Options;
            return new EducationalPracticeContext(options);
        }
    }
}