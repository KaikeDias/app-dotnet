using Microsoft.EntityFrameworkCore;

namespace projeto_cs1.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) 
        : base (options) 
        {
        }

        public DbSet<Usuario> Usuario {get; set;}
    }
}