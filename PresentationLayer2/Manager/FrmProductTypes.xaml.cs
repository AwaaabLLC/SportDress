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
    /// Interaction logic for FrmProductTypes.xaml
    /// </summary>
    public partial class FrmProductTypes : Window
    {
        private IManagerManager manager;
        public FrmProductTypes()
        {
            InitializeComponent();
            manager = new ManagerManager();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!validateFormData())
            {
                return;
            } 
            ProductTypes productTypes = new ProductTypes();
            productTypes.ProductTypeName = txtProductTypeName.Text;
            productTypes.Description = txtDescription.Text;
            int result = manager.addProductType(productTypes);
            if (result == 0)
            {
                lblFormMessage.Content = "there is an error, call admin";
                return;
            }
            lblFormMessage.Content = "added correctly";
        }

        private bool validateFormData()
        {
            if (txtProductTypeName.Text.Length == 0) {
                lblFormMessage.Content = "Enter a product type";
                return false;
            }
            if (txtDescription.Text.Length == 0)
            {
                lblFormMessage.Content = "Enter a description";
                return false;
            }
            lblFormMessage.Content = "";
            return true;
        }
    }
}
