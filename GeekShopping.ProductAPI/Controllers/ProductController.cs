using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository repository)
        {
            _productRepository = repository ?? throw new ArgumentNullException(nameof(repository)); 
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.FindAll();
            
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var product = await _productRepository.FindById(id);

            return product != null ? Ok(product) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(ProductVO data)
        {
            if (data == null) return BadRequest();

            var product = await _productRepository.Create(data);

            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> PutProduct(ProductVO data)
        {
            if (data == null) return BadRequest();

            var product = await _productRepository.Update(data);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            if (id.Equals(0)) return BadRequest();

            var isDeleted = await _productRepository.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }
    }
}
