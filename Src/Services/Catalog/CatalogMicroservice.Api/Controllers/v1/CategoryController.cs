using CatalogMicroservice.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogMicroservice.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts() =>
            Ok(await _categoryRepository.GetProducts());

        [HttpGet("GetAllProductsByName")]
        public async Task<IActionResult> GetProductByName([FromQuery] string name) =>
            Ok(await _categoryRepository.GetProductsByName(name));

        [HttpGet("GetAllProductByCategory")]
        public async Task<IActionResult> GetProductByCategory([FromQuery] string category) =>
            Ok(await _categoryRepository.GetProductsByCategory(category));

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Entities.ProductEntity entity)
        {
            await _categoryRepository.CreateProduct(entity);

            return Ok();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] Entities.ProductEntity entity)
        {
            var result = await _categoryRepository.UpdateProduct(entity);

            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            var result = await _categoryRepository.DeleteProduct(id);

            return Ok(result);
        }
    }
}
