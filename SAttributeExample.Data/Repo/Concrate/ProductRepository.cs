using SAttributeExample.Data.Repo.Abstract;
using SAttributeExample.Entity;

namespace SAttributeExample.Data.Repo.Concrate
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(SAttributeContext sAattributeContext) : base(sAattributeContext)
        {
        }
    }
}
