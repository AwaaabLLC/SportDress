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

        private void btnCustomerSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!validateCustomerForm())
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

        private bool validateCustomerForm()
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

        private void btnAddZipCode_Click(object sender, RoutedEventArgs e)
        {
            if (!validateZipcodeForm())
            {
                return;
            }
            Zipcode zipcode = new Zipcode();
            zipcode.zipcode = txtNewZipcode.Text;
            zipcode.city = txtCity.Text;
            zipcode.state = txtState.Text;
            int result = 0;
            result = customerManager.addZipCode(zipcode);
            if (result == 0)
            {
                lblFormNote.Content = "zipcode did not added!";
                return;
            }
            lblFormNote.Content = "zipcode added";
            fillCombos();
        }

        private bool validateZipcodeForm()
        {
            if (txtNewZipcode.Text.Length == 0)
            {
                lblFormNote.Content = "zipcode require";
                return false;
            }
            if (txtCity.Text.Length == 0)
            {
                lblFormNote.Content = "City require";
                return false;
            }
            if (txtState.Text.Length == 0)
            {
                lblFormNote.Content = "State require";
                return false;
            }
            lblFormNote.Content = "";
            return true;
        }

        private void btnAddCard_Click(object sender, RoutedEventArgs e)
        {
            if (!validateCardForm())
            {
                return;
            }
            lblFormNote.Content = "Credit Card data valid";
        }

        private bool validateCardForm()
        {
            if (comboCustomers.SelectedItem == null)
            {
                lblFormNote.Content = "Customer require";
                return false;
            }
            if (comboZipcodeCard.SelectedItem == null)
            {
                lblFormNote.Content = "Zipcode require";
                return false;
            }
            if (txtCCNumber.Text.Length == 0)
            {
                lblFormNote.Content = "Credit Card number require";
                return false;
            }
            if (txtCVV.Text.Length == 0)
            {
                lblFormNote.Content = "CVV require";
                return false;
            }
            if (txtDateOfBirth.Text.Length == 0)
            {
                lblFormNote.Content = "Date of Birth require";
                return false;
            }
            if (txtNameOnCard.Text.Length == 0)
            {
                lblFormNote.Content = "Name on card require";
                return false;
            }
            lblFormNote.Content = "";
            return true;
        }
    }
}
