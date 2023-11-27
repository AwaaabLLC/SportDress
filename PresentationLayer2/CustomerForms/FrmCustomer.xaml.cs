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
using ILogicLayer;
using LogicLayer;
using DataObjects;

namespace PresentationLayer.CustomerForms
{
    /// <summary>
    /// Interaction logic for FrmCustomer.xaml
    /// </summary>
    public partial class FrmCustomer : Window
    {
        private Customer customer;
        private ICustomersManager customerManager;
        private List<Zipcode> zipcodeList;
        public FrmCustomer()
        {
            InitializeComponent();
            customer = new Customer();
            customerManager = new CustomersManager();
            zipcodeList = new List<Zipcode>();
            fillCombos();
        }

        private void fillCombos()
        {
            zipcodeList = customerManager.getZipcodes();
            List<string> zipcodes = new List<string>();
            foreach (Zipcode code in zipcodeList)
            {
                if (code.zipcode != null)
                {
                    zipcodes.Add(code.zipcode);
                }
                
            }
            comboZipCode.ItemsSource = zipcodes; 
            comboZipCode.SelectedIndex = 0;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!validateForm())
            {
                return;
            }
            int result = 0;
            customer.GivenName = txtGivenName.Text;
            customer.FamilyName = txtFamilyName.Text;
            customer.PhoneNumber = txtPhoneNumber.Text;
            customer.Email = txtEmail.Text;
            customer.line1 = txtLine1.Text;
            customer.line2 = txtLine2.Text;
            customer.zipcode = comboZipCode.SelectedItem.ToString();
            result = customerManager.add(customer);
            if (result == 0)
            {
                lblFormNote.Content = "Customer did not added correctly";
                return;
            }
            lblFormNote.Content = "Customer added correctly";
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
            if (comboZipCode.SelectedItem == null)
            {
                lblFormNote.Content = "line 2 require";
                return false;
            }
            lblFormNote.Content = "";
            return true;
        }
    }
}
