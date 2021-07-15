using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DemoWebinarDbContext : DbContext
    {
        public DemoWebinarDbContext()
        {
            
        }

        public DemoWebinarDbContext(DbContextOptions<DemoWebinarDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Direction> Directions { get; set; }
    }
}