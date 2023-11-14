using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LogicLayer;
using ILogicLayer;
using DataObjects;

namespace PresentationLayer.Manager
{
    /// <summary>
    /// Interaction logic for FrmProducts.xaml
    /// </summary>
    public partial class FrmProducts : Window
    {
        private IManagerManager productManager = null;
        public FrmProducts()
        {
            InitializeComponent();
            productManager = new ManagerManager();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!validateData())
            {
                return;
            }
            int result = 0;
            Products product = new Products();
            product.ProductName = txtProductName.Text;
            product.Type = txtType.Text;
            product.Size = txtSize.Text;
            product.Price = txtPrice.Text;
            result = productManager.addProduct(product);
            if (result == 0)
            {
                lblFormMessage.Content = "there is an error, please try again";
                return;
            }
            lblFormMessage.Content = "Product added";
            clearForm();
        }

        private void clearForm()
        {
            txtProductName.Text = string.Empty;
            txtType.Text = string.Empty;
            txtSize.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }

        private bool validateData()
        {
            if (txtProductName.Text == string.Empty)
            {
                lblFormMessage.Content = "Product Name is require";
                return false;
            }
            if (txtType.Text == string.Empty)
            {
                lblFormMessage.Content = "Product Type is require";
                return false;
            }
            if (txtSize.Text == string.Empty)
            {
                lblFormMessage.Content = "Product Size is require";
                return false;
            }
            if (txtPrice.Text == string.Empty)
            {
                lblFormMessage.Content = "Product Price is require";
                return false;
            }
            lblFormMessage.Content = string.Empty;
            return true;
        }
    }
}
