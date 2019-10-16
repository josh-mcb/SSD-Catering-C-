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
using System.Collections.ObjectModel;


namespace SolutionCW
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Page
    {

         ObservableCollection<OrderClass> OrderList;

        public Order()
        {
            InitializeComponent();

            OrderList = new ObservableCollection<OrderClass>();

            Loaded += (s, e) => LoadOrders();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewOrder order = new NewOrder(this);

            order.Show();
        }

        private void orderGD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        public void LoadOrders()
        {

            OrderList.Clear();
            string ConnString = MainWindow.DBconnection;
            string CmdString = string.Empty;

            // the SQL connection is initialised here, calling the DB source declated above and creating a new insrance of the SQL connection "conn"

            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();

                // SQl Query selecting the columns intended to be displayed

                CmdString = "SELECT OrderID, CustID, [Order Date], [Function Date], Venue, [No of People], Starter, Main, Dessert, Price FROM [Order]";

                // SQl command calling the SQL code and applying it to the connection initialised above

                var cmd = new SqlCommand(CmdString, conn);

                // for Debug purposes, "reader" is initialised to call the SQL command "ExecuteReader()" which allows the contents of the SQL query to be read and 
                // displayed

                var reader = cmd.ExecuteReader();

                // while loop to read each line of the table and call it into an array. Assigning it to its correct format. Int or String in this case

                while (reader.Read())
                {
                    int oID = reader.GetInt32(0);
                    int cID = reader.GetInt32(1);
                    DateTime oDATE = reader.GetDateTime(2);
                    DateTime fDATE = reader.GetDateTime(3);
                    var venue = reader.GetString(4);
                    int people = reader.GetInt32(5);
                    var course1 = reader.GetInt32(6);
                    var course2 = reader.GetInt32(7);
                    var course3 = reader.GetInt32(8);
                    var price = reader.GetDecimal(9);

                    using (var conn2 = new SqlConnection(MainWindow.DBconnection))
                    {
                        var command2 = new SqlCommand("SELECT Description FROM Courses WHERE MealID = @id", conn2);

                        command2.Parameters.AddWithValue("@id", course1);
                        
                       
                        conn2.Open();

                        string course1Name = command2.ExecuteScalar() as string;
                        command2.Parameters.Clear();
                        
                        

                        using (var conn3 = new SqlConnection(MainWindow.DBconnection))

                        {

                            var command3 = new SqlCommand("SELECT Description FROM Courses WHERE MealID = @2id", conn3);

                            command3.Parameters.AddWithValue("@2id", course2);

                            conn3.Open();

                            string course2Name = command3.ExecuteScalar() as string;
                            command3.Parameters.Clear();


                            using (var conn4 = new SqlConnection(MainWindow.DBconnection))
                            {

                                var command4 = new SqlCommand("SELECT Description FROM Courses WHERE MealID = @3id", conn4);

                                command4.Parameters.AddWithValue("@3id", course3);

                                conn4.Open();

                                string course3Name = command4.ExecuteScalar() as string;
                                command4.Parameters.Clear();

                                // calls the SQL customer class and to use the get sets for each variable, this allows the contents to be added to the obserable collection

                                OrderClass order = new OrderClass(oID, cID, oDATE, fDATE, venue, people, course1Name, course2Name, course3Name, price);

                                OrderList.Add(order);
                            }
                        }
                    }

                }

                orderGD.ItemsSource = OrderList;



            }


        }
    }
}
