using Microsoft.EntityFrameworkCore;

namespace RegisterLoging.Models
{
    class MyDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MyDb.db");
        }
        public DbSet<Person> People { get; set; }
    }
}