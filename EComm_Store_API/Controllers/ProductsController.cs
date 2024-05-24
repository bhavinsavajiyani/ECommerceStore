using EComm_Store_Core.Entities;
using EComm_Store_Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EComm_Store_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // api/products
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            Product? product = await _context.Products.FindAsync(id);
            return product != null ? product :  NotFound();
        }
    }
}