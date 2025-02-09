using LearningVocab.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningVocab.Datas
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Word> Words { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
