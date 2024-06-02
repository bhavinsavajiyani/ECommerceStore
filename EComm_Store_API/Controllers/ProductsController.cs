using EComm_Store_Core.Entities;
using EComm_Store_Core.Interfaces;
using EComm_Store_Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace EComm_Store_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandsRepo;
        private readonly IGenericRepository<ProductType> _productTypesRepo;

        public ProductsController(
                IGenericRepository<Product> productsRepo,
                IGenericRepository<ProductBrand> productBrandsRepo,
                IGenericRepository<ProductType> productTypesRepo)
        {
            _productsRepo = productsRepo;
            _productBrandsRepo = productBrandsRepo;
            _productTypesRepo = productTypesRepo;
        }

        [HttpGet] // URL: api/products
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
            var spec = new ProductsWithBrandsAndTypesSpecification();
            return Ok(await _productsRepo.GetCollectionAsync(spec));
        }

        [HttpGet("{id:int}")]  // URL: api/products/id => E.g.: api/products/1
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var spec = new ProductsWithBrandsAndTypesSpecification(id);
            return await _productsRepo.GetEntityWithSpec(spec);
        }

        [HttpGet("brands")] // URL: api/products/brands
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandsRepo.GetCollectionAsync());
        }

        [HttpGet("types")] // URL: api/products/type
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypesRepo.GetCollectionAsync());
        }
    }
}