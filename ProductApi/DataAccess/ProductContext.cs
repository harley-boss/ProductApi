// Project:     SOA_A4
// Class:       Software oriented architecture
// File:        ProductContext.cs
// Developer:   Harley Boss
// Date:        November 5th 2019
// Description: Data access layer for querying the database


using Microsoft.EntityFrameworkCore;
using ProductApi.Models;


namespace ProductApi.DataAccess {

    public class ProductContext : DbContext {

        public ProductContext(DbContextOptions<ProductContext> options) : base(options) {}

        public ProductContext() {}

        public DbSet<Product> Product { get; set; }
    }
}

