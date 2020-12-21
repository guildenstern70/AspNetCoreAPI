using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAPI.Models
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=aspnetcoreapi.db");
    }
}