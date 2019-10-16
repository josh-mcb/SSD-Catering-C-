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
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace SolutionCW
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Page
    {
        // declaration of observable collection, will contain the contents of the Customer table within the Database
        int custID;
        public ObservableCollection<customerSQL> custLst;
        

        public Customer()
        {
            InitializeComponent();

            // initiates the obseravle collection in the initialize component, allowing it to be used throughout the page

            custLst = new ObservableCollection<customerSQL>();
            
            // when the page is loaded the load customer method is called

            Loaded += (s, e) =>loadCustomers();
            

           
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void loadCustomers()
        {

            // calls the connection string from the mainwindow, the DB connecion is initalized their to be used throughout the project without needing 
            //  to create a new instance of the main window each time

            string ConnString = MainWindow.DBconnection;
            string CmdString = string.Empty;

            // the SQL connection is initialised here, calling the DB source declated above and creating a new insrance of the SQL connection "conn"

            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();

                // SQl Query selecting the columns intended to be displayed

                CmdString = "SELECT CustomerID, FirstName, LastName, PhoneNumber, Address, Postcode FROM Customer";

                // SQl command calling the SQL code and applying it to the connection initialised above

                var cmd = new SqlCommand(CmdString, conn);

                // for Debug purposes, "reader" is initialised to call the SQL command "ExecuteReader()" which allows the contents of the SQL query to be read and 
                // displayed

                var reader = cmd.ExecuteReader();

                // while loop to read each line of the table and call it into an array. Assigning it to its correct format. Int or String in this case

                while (reader.Read())
                {
                    Int32 id = reader.GetInt32(0);
                    var fName = reader.GetString(1);
                    var lname = reader.GetString(2);
                    var no = reader.GetString(3);
                    var add = reader.GetString(4);
                    var Pcode = reader.GetString(5);

                    // calls the SQL customer class and to use the get sets for each variable, this allows the contents to be added to the obserable collection

                    customerSQL CustSQL = new customerSQL(id, fName, lname, no, add, Pcode);
                    custLst.Add(CustSQL);
                    custID = id;
                }

                // displays the contents to the datagrid "CustomerDG"

                CustomerDG.IsReadOnly = true;
                CustomerDG.ItemsSource = custLst;

                conn.Close();
            }
            
        }

        public void searchQuery(string text)
        {
            // search query that will return the input of the form via second name and display in the datagrid via the observable collection

            var x = new ObservableCollection<customerSQL>(
                (from c in custLst where c.LastName.ToUpper() == text.ToUpper() select c).ToArray());

            

            CustomerDG.ItemsSource = x;
        }

        private void Addcustomer_Click(object sender, RoutedEventArgs e)
        {

            addCustomer showForm = new addCustomer(this);

            showForm.ShowDialog();

        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            customerSearch search = new customerSearch(this);

            search.ShowDialog();
        }

        private void editCustomer_CLick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Edit Mode Enabled");

            CustomerDG.IsReadOnly = false;


        }

        private void MarkButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) // Saves the changes made to the datagrid to the SQl table 
        {
            // new connection string declared

            string connString2 = MainWindow.DBconnection;
            string cmdString2 = string.Empty;

            // opening a new Sql connection 

            try
            {

                using (SqlConnection connection = new SqlConnection(connString2))
                {


                    cmdString2 = ("UPDATE Customer SET FirstName = @Value1, LastName = @Value2, PhoneNumber = @Value3, Address = @Value4, Postcode = @Value5 WHERE CustomerID = @id");

                    SqlCommand comm = new SqlCommand(cmdString2, connection);
                    connection.Open();

                    foreach (var record in custLst)
                    {

                        comm.Parameters.Clear();
                        comm.Parameters.AddWithValue("@id", record.ID);
                        comm.Parameters.AddWithValue("@Value1", record.FirstName);
                        comm.Parameters.AddWithValue("@Value2", record.LastName);
                        comm.Parameters.AddWithValue("@Value3", record.PhoneNumber);
                        comm.Parameters.AddWithValue("@Value4", record.address);
                        comm.Parameters.AddWithValue("@Value5", record.PostCode);
                        int i = comm.ExecuteNonQuery();
                        comm.ExecuteNonQuery();
                        System.Diagnostics.Debug.Assert(i == 1);


                    }

                    MessageBox.Show("Changes Saved");

                }
            }

                catch
            {
                MessageBox.Show("An Error has occured, Please Try Again!");

            }
            

            


                

                    // SQL code to update the changes to the table

                    

                

               








            }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            custLst.Clear();

            loadCustomers(); 
        }
    }
    }


        

