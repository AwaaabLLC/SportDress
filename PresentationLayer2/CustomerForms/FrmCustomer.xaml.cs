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
        private List<Customer> customerList;
        private CustomerCreditCard creditCard;
        public FrmCustomer()
        {
            InitializeComponent();
            customer = new Customer();
            customerList = new List<Customer>();
            customerManager = new CustomersManager();
            creditCard = new CustomerCreditCard();
            zipcodeList = new List<Zipcode>();
            fillCombos();
        }

        private void fillFormsDataByCustomerInfo()
        {
            txtGivenName.Text = customer.GivenName;
            txtFamilyName.Text = customer.FamilyName;
            txtPhoneNumber.Text = customer.PhoneNumber;
            txtEmail.Text = customer.Email;
            txtLine1.Text = customer.line1;
            txtLine2.Text = customer.line2;
            comboZipCode.SelectedItem = customer.zipcode;
            Zipcode zipcode = new Zipcode();
            foreach (Zipcode code in zipcodeList)
            {
                if (code.zipcode == customer.zipcode)
                {
                    zipcode = code; break;
                }
            }
            txtNewZipcode.Text = customer.zipcode;
            txtState.Text = zipcode.state;
            txtCity.Text = zipcode.city;
            comboCustomers.SelectedItem = customer.FamilyName;
            comboZipCode.SelectedItem =customer.zipcode;
            creditCard = customerManager.getCustomerCreditCard(customer.CustomerID);
            txtCCNumber.Text = creditCard.CreditCardNumber;
            txtCVV.Text = creditCard.cvv;
            txtDateOfBirth.Text = creditCard.dateOfExpiration;
            txtNameOnCard.Text = creditCard.nameOnTheCard;
            txtNewZipcode.IsReadOnly = true;
            txtState.IsReadOnly = true;
            txtCity.IsReadOnly = true;
            btnAddZipCode.IsEnabled = false;
            btnSubmit.Content = "Update Customer";
            btnAddCard.Content = "Update Card";
        }

        public FrmCustomer(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            customerList = new List<Customer>();
            customerManager = new CustomersManager();
            creditCard = new CustomerCreditCard();
            zipcodeList = new List<Zipcode>();
            fillCombos();
            fillFormsDataByCustomerInfo();
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
            customerList = customerManager.getAllCustomers();
            List<string> customerNames = new List<string>();
            foreach (Customer custom in customerList) {
                if (custom.FamilyName != null)
                customerNames.Add(custom.FamilyName);
            }
            comboCustomers.ItemsSource = customerNames;
            comboCustomers.SelectedIndex = 0;
            comboZipcodeCard.ItemsSource = zipcodes;
            comboZipcodeCard.SelectedIndex = 0;
            txtNewZipcode.IsReadOnly = false;
            txtState.IsReadOnly = false;
            txtCity.IsReadOnly = false;
            btnAddZipCode.IsEnabled = true;
            btnSubmit.Content = "Add Customer";
            btnAddCard.Content = "Add Card";

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
            if (btnSubmit.Content.ToString() == "Add Customer")
            {
                result = customerManager.add(customer);
            }
            else
            {
                result = customerManager.update(customer);
            }
            
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
            foreach (Customer custom in customerList)
            {
                if (custom.FamilyName != null && custom.FamilyName.Equals(comboCustomers.SelectedItem.ToString()))
                {
                    creditCard.CustomerID = custom.CustomerID;
                    break;
                }
            }            
            creditCard.CreditCardNumber = txtCCNumber.Text;
            creditCard.zipcode = comboZipCode.SelectedItem.ToString();
            creditCard.cvv = txtCVV.Text;
            creditCard.dateOfExpiration = txtDateOfBirth.Text;
            creditCard.nameOnTheCard = txtNameOnCard.Text;
            int result = 0;
            if (btnAddCard.Content.ToString() == "Add Card")
            {
                result = customerManager.addCustomerCreditCard(creditCard);
            }
            else
            {
                result = customerManager.updateCustomerCreditCard(creditCard);
            }
            
            if (result == 0)
            {
                lblFormNote.Content = "Credit Card did not added";
                return;
            }
            lblFormNote.Content = "Credit Card added";
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
