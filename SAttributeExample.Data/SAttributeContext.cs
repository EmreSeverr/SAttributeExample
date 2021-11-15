using Microsoft.EntityFrameworkCore;
using SAttributeExample.Entity;

namespace SAttributeExample.Data
{
    public class SAttributeContext : DbContext
    {
        public SAttributeContext(DbContextOptions<SAttributeContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
