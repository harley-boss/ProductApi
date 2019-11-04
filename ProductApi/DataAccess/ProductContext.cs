using Microsoft.EntityFrameworkCore;
using ProductApi.Models;


namespace ProductApi.DataAccess {

    public class ProductContext : DbContext {

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options) {

        }


        public ProductContext() {

        }

        public DbSet<Product> Product { get; set; }
    }
}

