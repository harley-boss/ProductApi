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
