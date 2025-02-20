using API.DTO;
using API.Entities;
using API.Repositories.Interface;
using AutoMapper;
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
    }
}
