using SimpleInventoryManagementSystem.Business;
using SimpleInventoryManagementSystem.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SimpleInventoryManagementSystem
{
    public partial class MainForm : Form
    {
        private InventoryManager _inventoryManager;

        public MainForm()
        {
            InitializeComponent();
            _inventoryManager = new InventoryManager();
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgvProducts.DataSource = _inventoryManager.GetAllProducts();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            if (productForm.ShowDialog() == DialogResult.OK)
            {
                _inventoryManager.AddProduct(productForm.Product);
                LoadProducts();
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int productId = (int)dgvProducts.SelectedRows[0].Cells[0].Value;
                Product product = _inventoryManager.GetAllProducts().FirstOrDefault(p => p.ProductID == productId);
                if (product != null)
                {
                    ProductForm productForm = new ProductForm(product);
                    if (productForm.ShowDialog() == DialogResult.OK)
                    {
                        _inventoryManager.UpdateProduct(productForm.Product);
                        LoadProducts();
                    }
                }
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int productId = (int)dgvProducts.SelectedRows[0].Cells[0].Value;
                _inventoryManager.DeleteProduct(productId);
                LoadProducts();
            }
        }

        private void btnAdjustStock_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int productId = (int)dgvProducts.SelectedRows[0].Cells[0].Value;
                int quantity = (int)nudQuantity.Value;
                _inventoryManager.AdjustStock(productId, quantity);
                LoadProducts();
            }
        }

        private void btnLowStock_Click(object sender, EventArgs e)
        {
            dgvProducts.DataSource = _inventoryManager.GetLowStockProducts();
        }
    }
}
