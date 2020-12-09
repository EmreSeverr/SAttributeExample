using SAAttributesExample.Entitiy;
using SAttributeExample.Data.Repo.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAttributeExample.Data.Repo.Concrate
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(SAattributeContext sAattributeContext) : base(sAattributeContext)
        {
        }
    }
}
