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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace SolutionCW
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        private bool validUsers { get; set; }

        // SQL connection, can be used to 

        public static string DBconnection = System.Configuration.ConfigurationManager.ConnectionStrings["EUproj"].ConnectionString;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            // assigning new variables to user input textboxes

            string password = password_input.Text;
            string userName = username_input.Text;

            // creating a boolean variable to verify log in details

            bool validUsers = false;

            // Creating a string that locates text file that register form writes to.

            string path = @"Login.txt";


            // foreach statement to read all lines in text file.
            // string[] lines = File.ReadAllLines(path);
            foreach (var line in File.ReadAllLines(path))
            {

                // splits the text file at the colons (username:password)

                string textUserName = line.Split(',')[0].Trim();
                string textPassword = line.Split(',')[1].Trim();


               

                if (textUserName == userName && textPassword == password)
                {
                    validUsers = true;

                }

            }




            // if statement to check if user inputted correct details

            

            if (!validUsers)
            {
                MessageBox.Show("You have entered invalid details. Please try again or Contact Admin!");

            }




            // if the user enters the correct login details - displays main menu form.

            if(validUsers == true)
            {
                MessageBox.Show("You have sucessfully logged in!");


                HomeScreen showmenu = new HomeScreen();

                this.Close();

                showmenu.ShowDialog();

            }
        }



   
 
        private void Button_Click(object sender, RoutedEventArgs e) // admin Button
        {
            adminlogin showPage = new adminlogin();

            this.Close();

            showPage.ShowDialog();




            

        }
    }
}



