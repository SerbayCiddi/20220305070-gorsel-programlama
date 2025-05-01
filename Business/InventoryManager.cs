using SimpleInventoryManagementSystem.Data;
using System.Collections.Generic;
using System.Linq;

namespace SimpleInventoryManagementSystem.Business
{
    public class InventoryManager
    {
        private InventoryContext _context;

        public InventoryManager()
        {
            _context = new InventoryContext();
            _context.Database.EnsureCreated();
        }

        public List<Product> GetAllProducts() => _context.Products.ToList();

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public void AdjustStock(int productId, int quantity)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                product.Quantity += quantity;
                _context.SaveChanges();
            }
        }

        public List<Product> GetLowStockProducts() =>
            _context.Products.Where(p => p.Quantity <= p.ReorderLevel).ToList();
    }
}
