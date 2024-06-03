using AutoMapper;
using EComm_Store_API.DTOs;
using EComm_Store_API.Errors;
using EComm_Store_Core.Entities;
using EComm_Store_Core.Interfaces;
using EComm_Store_Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace EComm_Store_API.Controllers
{
    public class ProductsController : BaseAPIController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandsRepo;
        private readonly IGenericRepository<ProductType> _productTypesRepo;
        private readonly IMapper _mapper;

        public ProductsController(
                IGenericRepository<Product> productsRepo,
                IGenericRepository<ProductBrand> productBrandsRepo,
                IGenericRepository<ProductType> productTypesRepo,
                IMapper mapper)
        {
            _productsRepo = productsRepo;
            _productBrandsRepo = productBrandsRepo;
            _productTypesRepo = productTypesRepo;
            _mapper = mapper;
        }

        [HttpGet] // URL: api/products
        public async Task<ActionResult<IReadOnlyList<ProductDTO>>> GetProducts(string sort)
        {
            var spec = new ProductsWithBrandsAndTypesSpecification(sort);
            var products = await _productsRepo.GetCollectionAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(products));
        }

        [HttpGet("{id:int}")]  // URL: api/products/id => E.g.: api/products/1
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var spec = new ProductsWithBrandsAndTypesSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);

            if(product == null)
            {
                return NotFound(new APIErrorResponse(404));
            }

            return _mapper.Map<Product, ProductDTO>(product);
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