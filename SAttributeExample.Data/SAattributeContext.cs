using Microsoft.EntityFrameworkCore;
using SAAttributesExample.Entitiy;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAttributeExample.Data
{
    public class SAattributeContext : DbContext
    {
        public SAattributeContext(DbContextOptions<SAattributeContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
