using SimpleInventoryManagementSystem.Data;
using System;
using System.Windows.Forms;

namespace SimpleInventoryManagementSystem
{
    public partial class ProductForm : Form
    {
        public Product Product { get; private set; }

        public ProductForm()
        {
            InitializeComponent();
            Product = new Product();
        }

        public ProductForm(Product product) : this()
        {
            Product = product;
            txtName.Text = product.Name;
            txtCategory.Text = product.Category;
            nudQuantity.Value = product.Quantity;
            nudPrice.Value = product.Price;
            nudReorderLevel.Value = product.ReorderLevel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Product.Name = txtName.Text;
            Product.Category = txtCategory.Text;
            Product.Quantity = (int)nudQuantity.Value;
            Product.Price = nudPrice.Value;
            Product.ReorderLevel = (int)nudReorderLevel.Value;
            DialogResult = DialogResult.OK;
        }
    }
}
