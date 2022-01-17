using System.Collections;
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

        public static DbContextOptions<EducationalPracticeContext> GetOptions()
        {
            return new DbContextOptionsBuilder<EducationalPracticeContext>().Options;
        }
        
        public static EducationalPracticeContext InitDatabase()
        {
            return new EducationalPracticeContext(GetOptions());
        }
    }
}