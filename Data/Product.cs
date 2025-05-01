using System.ComponentModel.DataAnnotations;

namespace SimpleInventoryManagementSystem.Data
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ReorderLevel { get; set; }
    }
}
