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
using DataObjects;


namespace PresentationLayer.Admin
{
    /// <summary>
    /// Interaction logic for EmployeeDataForm.xaml
    /// </summary>
    public partial class EmployeeDataForm : Window
    {
        Employee? employee = null;
        public EmployeeDataForm()
        {
            InitializeComponent();
            lblTitleForm.Content = "New Employee";
        }
        public EmployeeDataForm(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            lblTitleForm.Content = "Edit Employee";
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            lblFormMessage.Content = "أواب";
        }
    }
}
