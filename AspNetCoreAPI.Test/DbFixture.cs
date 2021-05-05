using AspNetCoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreAPI.Test
{
    public class DbFixture
    {
        private readonly DbContextOptions<PersonContext> _contextOptions;
        
        public DbFixture()
        {
            this._contextOptions = new DbContextOptionsBuilder<PersonContext>()
                .UseSqlite("Data Source=aspnetcoreapi.db")
                .Options;
        }
        
        public void Initialize()
        {
            var db = new PersonContext(this._contextOptions);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}