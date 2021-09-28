using Data.Models;
using Microsoft.EntityFrameworkCore;


namespace Data.Context
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options)
          : base(options)
        { }
        public DbSet<Number> Numbers { get; set; }
    }
}