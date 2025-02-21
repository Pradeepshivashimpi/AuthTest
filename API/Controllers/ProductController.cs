using API.DTO;
using API.Entities;
using API.Repositories.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }


        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            // Map DTO to Domain Model using AutoMapper
            var product = mapper.Map<Product>(productDto);
            await productRepository.CreateProductAsync(product);

            // Map Domain Model to Response DTO
            var response = mapper.Map<ProductDto>(product);

            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.ID)
            {
                return BadRequest("Product ID mismatch");
            }

            var updatedProduct = await productRepository.UpdateProduct(product);

            if (updatedProduct == null)
            {
                return NotFound("Product not found");
            }

            return Ok(updatedProduct);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByID(int id)
        {
            var existingProduct = await productRepository.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            // Use AutoMapper to map to CategoryDto
            var response = mapper.Map<ProductDto>(existingProduct);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await productRepository.GetAllProductsAsync();
            return Ok(products);
        }
    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await productRepository.DeleteProductAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            // Use AutoMapper to convert the domain model to DTO
            var response = mapper.Map<ProductDto>(product);
            return Ok(new { Message = "Product deleted successfully" });
        }
    }

}

