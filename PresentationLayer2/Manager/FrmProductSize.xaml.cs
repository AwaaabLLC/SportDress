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
    /// Interaction logic for FrmProductSize.xaml
    /// </summary>
    public partial class FrmProductSize : Window
    {
        private IManagerManager manager;
        private ProductSizes productSize;

        public FrmProductSize()
        {
            InitializeComponent();
            manager = new ManagerManager();
        }

        public FrmProductSize(ProductSizes productSize)
        {
            this.productSize = productSize;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!validateForm())
            {
                return;
            }
            ProductSizes productSizes = new ProductSizes();
            productSizes.ProductsSizeName = txtProductSizeName.Text;
            productSizes.Description = txtDescription.Text;
            int result = manager.addProductSize(productSizes);
            if (result == 0)
            {
                lblFormMessage.Content = "Product size did not added!";
            }
            lblFormMessage.Content = "Product Size Added";
            clearForm();
        }

        private void clearForm()
        {
            txtProductSizeName.Text = "";
            txtDescription.Text = "";
        }

        private bool validateForm()
        {
            if (txtProductSizeName.Text.Length == 0) {
                lblFormMessage.Content = "product size name is require";
                return false;
            }
            if (txtProductSizeName.Text.Length > 4)
            {
                lblFormMessage.Content = "product size name max four chars";
                return false;
            }
            if (txtDescription.Text.Length == 0)
            {
                lblFormMessage.Content = "description is require";
                return false;
            }
            lblFormMessage.Content = "";
            return true;
        }
    }
}
