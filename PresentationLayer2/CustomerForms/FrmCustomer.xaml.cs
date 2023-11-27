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

namespace PresentationLayer.CustomerForms
{
    /// <summary>
    /// Interaction logic for FrmCustomer.xaml
    /// </summary>
    public partial class FrmCustomer : Window
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!validateForm())
            {
                return;
            }
            lblFormNote.Content = "testing";
        }

        private bool validateForm()
        {
            if (txtGivenName.Text.Length == 0)
            {
                lblFormNote.Content = "Given name require";
                return false;
            }
            if (txtFamilyName.Text.Length == 0)
            {
                lblFormNote.Content = "Family name require";
                return false;
            }
            if (txtPhoneNumber.Text.Length == 0)
            {
                lblFormNote.Content = "Phone Number require";
                return false;
            }
            if (txtEmail.Text.Length == 0)
            {
                lblFormNote.Content = "Email require";
                return false;
            }
            if (txtLine1.Text.Length == 0)
            {
                lblFormNote.Content = "Line 1 require";
                return false;
            }
            if (txtLine2.Text.Length == 0)
            {
                lblFormNote.Content = "line 2 require";
                return false;
            }
            lblFormNote.Content = "";
            return true;
        }
    }
}
