// Project:     SOA_A4
// Class:       Software oriented architecture
// File:        ProductController.cs
// Developer:   Harley Boss
// Date:        November 5th 2019
// Description: This is the controller class that handles all the calls to the product table in the shopping db


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.DataAccess;
using ProductApi.Models;

namespace ProductApi.Controllers {

    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {

        private readonly ProductContext _context;

        // Method:      ProductController
        // Parameters:  ProductContext context
        // Return:      n/a
        // Description: Initiates the ProductController class
        public ProductController(ProductContext context) {
            _context = context;
        }




        // Method:      GetProduct
        // Parameters:  n/a
        // Return:      async Task<ActionResult<IEnumerable<Product>>>
        // Description: Returns all products from the database
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct() {
            return await _context.Product.ToListAsync();
        }




        // Method:      GetProduct
        // Parameters:  [FromRoute] int id
        // Return:      async Task<ActionResult<Product>>
        // Description: Returns a product from the database based on an id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct([FromRoute] int id) {
            System.Diagnostics.Debug.WriteLine("Finding product with id: " + id);

            var product = await _context.Product.FindAsync(id);

            if (product == null) {
                return NotFound();
            }

            return product;
        }




        // Method:      PutProduct
        // Parameters:  int id, Product product
        // Return:      async Task<IActionResult>
        // Description: Update a product into the database
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product) {
            if (id != product.prodId) {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!ProductExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }




        // Method:      PostCustomer
        // Parameters:  Product product
        // Return:      async Task<ActionResult<Product>>
        // Description: Insert a product into the db
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product) {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.prodId }, product);
        }




        // Method:      DeleteProduct
        // Parameters:  int id
        // Return:      async Task<ActionResult<Product>>
        // Description: Deletes a product from the db based on id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id) {
            var product = await _context.Product.FindAsync(id);
            if (product == null) {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }




        // Method:      ProductExists
        // Parameters:  int id
        // Return:      bool
        // Description: Returns true or false if a id exists in the database
        private bool ProductExists(int id) {
            return _context.Product.Any(e => e.prodId == id);
        }
    }
}
