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

namespace SolutionCW
{
    /// <summary>
    /// Interaction logic for adminlogin.xaml
    /// </summary>
    public partial class adminlogin : Window
    {
        public adminlogin()
        {
            InitializeComponent();
        }

        private void adminloginbtn_Click(object sender, RoutedEventArgs e)
        {

            // simple code to access admin section, the admin section will simply be able to create new users.

            string password = adminlogin_pwoinput.Text;

            Boolean validAdmin = false;

                if (!password.Contains("adminUser123"))
                {

                    validAdmin = false;

                    MessageBox.Show("Incorrect Password, Please Try Again.");

                }

                else
                {

                    validAdmin = true;
                }

                if (validAdmin == true)
                {
                    adminFeaturesd featuresd = new adminFeaturesd();

                    this.Close();

                    featuresd.ShowDialog();
                }


            
            




        }
    }
}
