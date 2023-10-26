﻿using System.Text;
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
            gridBody.Visibility = Visibility.Collapsed;
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (btnLogin.Content.ToString() == "login")
            {
                lblLoginMessages.Content = "";                
                string username = txt_username.Text;
                string password = txt_password.Password.ToString();
                bool isUserNameValid = validateUserName(username);
                bool isPasswordValid = validatePassword(password);
                if (!(isUserNameValid && isPasswordValid))
                {
                    return;
                }
                int isEmployeeVerify = employeesManager.verifyEmployee(username, password);
                if (isEmployeeVerify < 1)
                {
                    lblLoginMessages.Content = "username and password are not correct";
                    return;
                }
                
                clearLoginText();
                hidLoginElements();
                List<string> employeeRoles = employeesManager.getEmployeeRoles(isEmployeeVerify);
                foreach (string item in employeeRoles)
                {
                    lblLoginMessages.Content += item;
                }
                showTabByRole(employeeRoles[0]);
                
            }
            else
            {
                showLoginElements();
            }
           
        }

        

        private void showTabByRole(string role)
        {
            lblLoginMessages.Content = role;
            gridBody.Visibility = Visibility.Visible;
            gridAdminMenu.Visibility = Visibility.Collapsed;    
             if (role == "admin")
            {
                btnAdmin.Visibility = Visibility.Visible;
                btnManager.Visibility = Visibility.Hidden;
                btnReciption.Visibility = Visibility.Hidden;
                gridAdminMenu.Visibility = Visibility.Visible;
            }
            else if(role == "manager")
            {
                btnAdmin.Visibility = Visibility.Hidden;
                btnManager.Visibility = Visibility.Visible;
                btnReciption.Visibility = Visibility.Hidden;
                gridAdminMenu.Visibility = Visibility.Hidden;
            }
            else if (role == "employee")
            {
                btnAdmin.Visibility = Visibility.Hidden;
                btnManager.Visibility = Visibility.Hidden;
                btnReciption.Visibility = Visibility.Visible;
                gridAdminMenu.Visibility = Visibility.Hidden;
            }
        }

        private void clearLoginText()
        {
            txt_username.Text = string.Empty;
            txt_password.Password = string.Empty;
        }

        private void showLoginElements()
        {
            lbl_username.Visibility = Visibility.Visible;
            lbl_password.Visibility = Visibility.Visible;
            txt_username.Visibility = Visibility.Visible;   
            txt_password.Visibility = Visibility.Visible;
            btnLogin.Content = "login";
            gridBody.Visibility = Visibility.Collapsed;
            lblLoginMessages.Content = "";
        }

        private void hidLoginElements()
        {
            lbl_username.Visibility = Visibility.Collapsed;
            lbl_password.Visibility = Visibility.Collapsed;
            txt_password.Visibility = Visibility.Collapsed; 
            txt_username.Visibility = Visibility.Collapsed;
            btnLogin.Content = "logout";
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

        private void btnNewUserClicked(object sender, RoutedEventArgs e)
        {
            Admin.EmployeeDataForm employeeDataForm = new Admin.EmployeeDataForm();
            employeeDataForm.Show();
        }
    }
}