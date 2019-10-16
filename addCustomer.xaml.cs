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
using System.Data.SqlClient;


namespace SolutionCW
{
    /// <summary>
    /// Interaction logic for addCustomer.xaml
    /// </summary>
    /// 

       

    public partial class addCustomer : Window
    {

        private Customer customer;

        public addCustomer(Customer customer)
        {
            this.customer = customer;

            InitializeComponent();
        }

        private void nameinput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e) // add customer button
        {
            string inputName = nameinput.Text;
            string inputLastname = secondnameinput.Text;
            string Number = phonenumber.Text;
            string address = addressinput.Text;
            string Pcode = postcode.Text;

            string allowedCharacters = "1234567890";

            if(inputName == "" && inputLastname == "" && Number == "" && address == "" && Pcode == "")

            {
                MessageBox.Show("You have entered no Data to be added to the table");
                return;
            }
            

            if(inputName == "")
            {
                MessageBox.Show("You have not entered a valid Name!");
                return;
            }

            if(inputLastname == "")
            {
                MessageBox.Show("You have not entered a valid  Last Name!");
                return;
            }

            if (address == "")
            {
                MessageBox.Show("You have not entered a valid Address");
                return;
            }

            if (Pcode == "" || Pcode.Length !=7)
            {
                MessageBox.Show("You have not entered a valid Postcode!");
                return;
            }


            if (Number == "" || Number.Length != 11)
            {
                MessageBox.Show("You have not entered a valid Number!");
                return;
            }



            else
            {
                foreach(var c in Number)
                {
                    if(!allowedCharacters.Contains(c))
                    {
                        MessageBox.Show("Invalid Mobile Number");
                        return;
                    }
                }
            }

           

            string cmdstring = "INSERT INTO Customer (FirstName, LastName, PhoneNumber, Address, Postcode) VALUES (@Name, @LastName, @Phone, @Addinput, @Pcode)";

            string connString = MainWindow.DBconnection;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandText = cmdstring;
                    comm.Parameters.AddWithValue("@Name", nameinput.Text);
                    comm.Parameters.AddWithValue("@LastName", secondnameinput.Text);
                    comm.Parameters.AddWithValue("@Phone", phonenumber.Text);
                    comm.Parameters.AddWithValue("@Addinput", addressinput.Text);
                    comm.Parameters.AddWithValue("@Pcode", postcode.Text);


                    try
                    {
                        Customer customer = new Customer();
                        conn.Open();
                        comm.ExecuteNonQuery();

                        MessageBox.Show("Customer Added");
        
                        conn.Close();          
                    }

                    catch(SqlException ex)
                    {


                        MessageBox.Show("There is a Problem with the information Entered. Error: " + ex.ErrorCode);
                      




                    }




                    customer.custLst.Clear();
                    customer.loadCustomers();
                    

                    this.Close();

                    

                   
                
                }


                

            }






        }




    }







}

    


