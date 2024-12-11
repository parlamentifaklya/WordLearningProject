using Microsoft.EntityFrameworkCore;
using WordLearningAPI.Models;

namespace WordLearningAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Word> Words { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }
    }
}
