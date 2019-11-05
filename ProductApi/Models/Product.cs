// Project:     SOA_A4
// Class:       Software oriented architecture
// File:        Product.cs
// Developer:   Harley Boss
// Date:        November 5th 2019
// Description: Shallow class representing a product


using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models {
    public class Product {

        [Key]
        public int prodId { get; set; }

        public string prodName { get; set; }

        public double price { get; set; }

        public double prodWeight { get; set; }

        public string inStock { get; set; }
    }
}
