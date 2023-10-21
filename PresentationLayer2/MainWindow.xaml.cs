using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LogicLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeesManager employeesManager;
        public MainWindow()
        {
            InitializeComponent();
            employeesManager = new EmployeesManager();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Password.ToString();
            bool isUserNameValid = validateUserName(username);
            bool isPasswordValid = validatePassword(password);
            if(!(isUserNameValid && isPasswordValid))
            {
                return;
            }
            bool isEmployeeVerify = employeesManager.verifyEmployee(username, password);
            if (!isEmployeeVerify)
            {
                lblLoginMessages.Content = "username and password are not correct";
                return;
            }
            lblLoginMessages.Content = "";

        }

        private bool validatePassword(string password)
        {
            bool result = true;
            if (password.Length < 8)
            {
                lblLoginMessages.Content = "minimum length of password is 8";
                result = false;
            }
            return result;
        }

        private bool validateUserName(string username)
        {
            bool result = true;
            if (username.Length < 8)
            {
                lblLoginMessages.Content = "minimum length of username is 8";
                result = false;
            }
            return result;
        }
    }
}