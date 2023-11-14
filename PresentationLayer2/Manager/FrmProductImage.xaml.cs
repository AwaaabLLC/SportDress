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
    /// Interaction logic for FrmProductImage.xaml
    /// </summary>
    public partial class FrmProductImage : Window
    {
        private IManagerManager productManager = null;
        public FrmProductImage()
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
            Images productImage = new Images();
            productImage.ProductId = Convert.ToInt32(txtProductId.Text);
            productImage.ImageUrl = txtURL.Text;

            result = productManager.addProductImage(productImage);
            if (result == 0)
            {
                lblFormMessage.Content = "there is an error, please try again later";
                return;
            }
            lblFormMessage.Content = "image added corectly";
            clearFormData();
        }

        private void clearFormData()
        {
            txtProductId.Text = string.Empty;
            txtURL.Text = string.Empty;
        }

        private bool validateData()
        {
            if (txtProductId.Text == string.Empty)
            {
                lblFormMessage.Content = "product Id require";
                return false;
            }
            if (txtURL.Text == string.Empty)
            {
                lblFormMessage.Content = "URL is require";
                return false;
            }
            lblFormMessage.Content = "";
            return true;
        }
    }
}
