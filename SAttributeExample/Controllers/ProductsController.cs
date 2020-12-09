using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAAttributesExample.Entitiy;
using SAttributeExample.Data.Repo.Abstract;
using SAttributeExample.DTOs;
using SAttributes.ActionFilters;
using System;
using System.Collections.Generic;
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

        [HttpGet("Product")]
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await _productRepository.GetAllAsync().ConfigureAwait(false));
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
