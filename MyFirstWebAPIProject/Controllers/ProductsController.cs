using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPIProject.Data;
using MyFirstWebAPIProject.Models;
using Newtonsoft.Json;

namespace MyFirstWebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
        }

        //private static List<Product> _products = new List<Product>
        //{
        //    new Product { Id = 1, Name = "Laptop", Price = 1000.00m, Category = "Electronics" },
        //    new Product { Id = 2, Name = "Desktop", Price = 2000.00m, Category = "Electronics" },
        //    new Product { Id = 3, Name = "Mobile", Price = 3000.00m, Category = "Electronics" },
        //    // Add more products
        //};
        // GET: api/products
        [HttpGet]
        public IActionResult GetProducts()
        {
            IEnumerable<Product> obj = _db.Products;
            return Ok(JsonConvert.SerializeObject(obj));
        }
        // GET: api/products/2
        [HttpGet("{id}")]
        [HttpGet("[action]")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }
        // POST: api/products
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            _db.Products.Add(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }
        // PUT: api/products/5
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            var existingProduct = _db.Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Category = product.Category;
            // In a real application, here you would update the product in the database
            return NoContent();
        }
        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _db.Products.Remove(product);
            // In a real application, here you would delete the product from the database
            return NoContent();
        }
    }
}
