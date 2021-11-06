using Microsoft.EntityFrameworkCore;

namespace Lesson2.Models
{
    public class ProductAppContext : DbContext
    {
        public ProductAppContext(DbContextOptions<ProductAppContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }
    }
}