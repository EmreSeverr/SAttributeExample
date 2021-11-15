using Microsoft.AspNetCore.Mvc;
using SAttributeExample.Data.Repo.Abstract;
using SAttributeExample.DTOs;
using SAttributeExample.Entity;
using SAttributes.ActionFilters;
using System.Linq;
using System.Threading.Tasks;

namespace SAttributeExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var product = await _productRepository.GetAllAsync().ConfigureAwait(false);

            var productDTO = product != null ?
                             (from p in product
                              select new ProductDTO
                              {
                                  Id = p.Id,
                                  Barcode = p.Barcode,
                                  Name = p.Name,
                                  UnitPrice = p.UnitPrice
                              }).ToList() : null;

            return Ok(productDTO);
        }

        [HttpPost("Product")]
        [SControllerFilter(RequirementDisabledProperties = "Id")]
        public async Task<IActionResult> AddProduct(ProductDTO productDTO)
        {
            var product = new Product
            {
                Barcode = productDTO.Barcode,
                Name = productDTO.Name,
                UnitPrice = productDTO.UnitPrice
            };

            await _productRepository.AddAsync(product).ConfigureAwait(false);

            return NoContent();
        }

        [HttpPut("Product")]
        [SControllerFilter]
        public IActionResult UpdateProduct(ProductDTO productDTO)
        {
            var product = new Product
            {
                Id = productDTO.Id,
                Barcode = productDTO.Barcode,
                Name = productDTO.Name,
                UnitPrice = productDTO.UnitPrice
            };

            _productRepository.Update(product);

            return NoContent();
        }
    }
}
