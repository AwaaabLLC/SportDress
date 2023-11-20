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
        private List<Products> products;
        public FrmProductImage()
        {
            InitializeComponent();
            productManager = new ManagerManager();
            products = new List<Products>();
            fillCombos();
        }

        private void fillCombos()
        {
            products = productManager.getProducts();
            List<int> ids = new List<int>();
            foreach (Products product in products)
            {
                ids.Add(product.ProductId);
            }
            comboProductId.ItemsSource = ids;
            comboProductId.SelectedIndex = 0;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!validateData())
            {
                return;
            } 
            int result = 0;
            Images productImage = new Images();
            if (comboProductId.SelectedItem.ToString != null)
            {
                lblFormMessage.Content = "Please select product";
                return;
            }
            productImage.ProductId = Convert.ToInt32(comboProductId.SelectedItem.ToString());
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
            comboProductId.SelectedIndex = 0;
            txtURL.Text = string.Empty;
        }

        private bool validateData()
        {
            if (comboProductId.SelectedItem == null)
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
