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
using System.IO;

namespace SolutionCW
{
    /// <summary>
    /// Interaction logic for adminFeaturesd.xaml
    /// </summary>
    public partial class adminFeaturesd : Window
    {
        public adminFeaturesd()
        {
            InitializeComponent();
        }



        private void registerbtn_Click(object sender, RoutedEventArgs e)
        {
            string bannedcharacter = ",";


            // if statement to ensure user enters a username

            if (usernametb.Text == "")
            {
                MessageBox.Show("Please Enter a UserName");
            }

            // if statement to ensure user enters a password

            else if (passwordtb.Text == "")
            {
                MessageBox.Show("Please Enter a Password");
            }

            // prevents users entering a colon on both the username input and password input (this corrupts the text file)q

            else if (usernametb.Text.Contains(bannedcharacter))
            {
                MessageBox.Show("Please Enter a Username without a colon!");

            }
            else if (passwordtb.Text.Contains(bannedcharacter))
            {
                MessageBox.Show("Please Enter a Password without a colon!");
            }



            // if both of the above if statements are met the streamwriter method writes the username and password to the text life "Login.txt"

            else
            {


                StreamWriter reg = new StreamWriter("Login.txt", true);

                reg.WriteLine(usernametb.Text + "," + passwordtb.Text);

                reg.Close();

                MessageBox.Show("You have now registered for the System! Continue via Login on the main menu!");



                

                MainWindow main = new MainWindow();

                main.ShowDialog();

                this.Close();

            }
        }
    }
}

