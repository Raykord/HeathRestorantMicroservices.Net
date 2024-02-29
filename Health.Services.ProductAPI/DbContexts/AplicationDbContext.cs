using Health.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Health.Services.ProductAPI.DbContexts
{
	public class AplicationDbContext : DbContext
	{
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) 
        {
                  
        }

        public DbSet<Product> Products { get; set; }
    }
}
