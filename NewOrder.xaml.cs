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
    /// Interaction logic for NewOrder.xaml
    /// </summary>
    public partial class NewOrder : Window
    {
        private List<Tuple<int, string, string>> CustomerList;
        private List<Tuple<int, string, decimal>> StarterList;
        private List<Tuple<int, string, decimal>> MainList;
        private List<Tuple<int, string, decimal>> DessertList;
        private Order win;
        

        addCardDetailsForm addCard = new addCardDetailsForm();


        public static int customerIDstat { get; set; }
        
        public NewOrder(Order win)
        {
            this.win = win;
           
            
            InitializeComponent();

           

            


            if (deliverycheckbox.IsChecked == true)
            {

                venue.IsReadOnly = false;

            }

            


            if (deliverycheckbox.IsChecked == false)
            {
                venue.IsReadOnly = true;

                venue.Text = "This Order will be Collected";

            }



            CustomerList = new List<Tuple<int, string, string>>();
            StarterList = new List<Tuple<int, string, decimal>>();
            MainList = new List<Tuple<int, string, decimal>>();
            DessertList = new List<Tuple<int, string, decimal>>();

            // Three Lists here for Dessert, Main and Starter WHERE Course = 1, 2, 3 (OR) 

            using (SqlConnection conn = new SqlConnection(MainWindow.DBconnection))
            {

                // command 

                var SQLcomm = new SqlCommand("SELECT CustomerID, FirstName + ' ' + LastName, Address FROM Customer", conn);
                conn.Open();
                var reader = SQLcomm.ExecuteReader();

                // while loop to read contents and add to Tuple List

                while(reader.Read())
                { 
                    CustomerList.Add(new Tuple<int, string, string>(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                }


                reader.Close();

                SQLcomm.CommandText = "SELECT MealID, Description, Price FROM Courses WHERE CourseNo = 1";

                reader = SQLcomm.ExecuteReader();

                while(reader.Read())
                {
                    StarterList.Add(new Tuple<int, string, decimal>(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2)));
                }

                reader.Close();

                SQLcomm.CommandText = "SELECT MealID, Description, Price FROM Courses WHERE CourseNo = 2";

                reader = SQLcomm.ExecuteReader();

                while(reader.Read())
                {

                    MainList.Add(new Tuple<int, string, decimal>(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2)));

                }

                reader.Close();

                SQLcomm.CommandText = "SELECT MealID, Description, Price FROM Courses WHERE CourseNo = 3";

                reader = SQLcomm.ExecuteReader();

                while (reader.Read())
                {

                    DessertList.Add(new Tuple<int, string, decimal>(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2)));

                }

                reader.Close();

                


            }

            // adds the tuple list conents to the Comboboxes

            customerCB.ItemsSource = from c in CustomerList select c.Item2;
            starterCB.ItemsSource = from c in StarterList select c.Item2;
            mainCB.ItemsSource = from c in MainList select c.Item2;
            dessertCB.ItemsSource = from c in DessertList select c.Item2;


        }

       

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // CustomerID ComboBox
        {
            

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // CustomerID listbox
        {

            
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e) // combo box
        {

        }

     
        private void Button_Click(object sender, RoutedEventArgs e) // submit button
        {

            // validation for input

            string people = number.Text;

            string allowedCharacters = "1234567890";

            try
            {


                if (number.Text == "")
                {
                    MessageBox.Show("You have not Entered a Valid Number of People");
                    return;

                }

                if (customerCB.Text == "")
                {
                    MessageBox.Show("You Have not selected a Valid Customer!");
                    return;
                }


                if (starterCB.Text == "")
                {

                    MessageBox.Show("You have not entered a Valid Starter!");
                    return;
                }


                if (mainCB.Text == "")
                {
                    MessageBox.Show("You have not entered a Valid Main!");
                    return;

                }

                if (dessertCB.Text == "")
                {
                    MessageBox.Show("You have not entered a Valid Dessert");
                    return;
                }

                if(orderdate.SelectedDate == null)
                {

                    MessageBox.Show("No OrderDate Selected");
                    return;
                        

                }

                if(functiondate.SelectedDate == null)
                {
                    MessageBox.Show("No Function Date Selected");
                    return;
                }



                else
                {

                    // foreach list to check to

                    foreach (var c in people)
                    {
                        if (!allowedCharacters.Contains(c))
                        {
                            MessageBox.Show("You have not entered a Number in the Number of People Textbox!");
                            return;

                        }
                    }

                }

            }


            catch(SqlException ex)
            {
                MessageBox.Show("There has been a DataBase Error, Please Ensure all Data is entered. SQL ERROR: " + ex.Message);

            }



            int numberofPeople = Convert.ToInt32(number.Text);

            int customerid = CustomerList[customerCB.SelectedIndex].Item1;
            string custname = CustomerList[customerCB.SelectedIndex].Item2;
            string address = CustomerList[customerCB.SelectedIndex].Item3;
            int Starter = StarterList[starterCB.SelectedIndex].Item1;
            int Main = MainList[mainCB.SelectedIndex].Item1;
            int Dessert = DessertList[dessertCB.SelectedIndex].Item1;

            string StarterName = StarterList[starterCB.SelectedIndex].Item2;
            string MainName = MainList[mainCB.SelectedIndex].Item2;
            string DessertName = DessertList[dessertCB.SelectedIndex].Item2;

            decimal Starterprice = StarterList[starterCB.SelectedIndex].Item3;
            decimal Mainprice = MainList[mainCB.SelectedIndex].Item3;
            decimal DessertPrice = MainList[dessertCB.SelectedIndex].Item3;


            decimal TotalPrice = Starterprice * numberofPeople + Mainprice * numberofPeople + DessertPrice * numberofPeople;

            using (var conn = new SqlConnection(MainWindow.DBconnection))
            {
                var command = new SqlCommand("INSERT INTO [Order] (CustID, [Order Date], [Function Date], Venue, [No of People], Starter, Main, Dessert, Price)"
                    + " VALUES (@CID, @oDate, @FDate, @venue, @people, @course1, @course2, @course3, @price)", conn);

                command.Parameters.AddWithValue("@CID", customerid);
                command.Parameters.AddWithValue("@oDate", orderdate.SelectedDate);
                command.Parameters.AddWithValue("@FDate", functiondate.SelectedDate);
                command.Parameters.AddWithValue("@venue", venue.Text);
                command.Parameters.AddWithValue("@people", number.Text);
                command.Parameters.AddWithValue("@course1", Starter);
                command.Parameters.AddWithValue("@course2", Main);
                command.Parameters.AddWithValue("@course3", Dessert);
                command.Parameters.AddWithValue("@price", TotalPrice);

                try
                {

                    conn.Open();
                    
                    command.ExecuteNonQuery();

                    conn.Close();


                }

                catch (SqlException ex)
                {

                    MessageBox.Show("There is a problem with the Data Entered : Error Code : " + ex.Message);


                }

                win.LoadOrders();

                // adding to invoice

                var command2 = new SqlCommand("INSERT INTO Invoice (CustomerID, Name, Address, OrderDate, Qty, Starter, Main, Dessert, Total) VALUES (@value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8, @value9)", conn);

                command2.Parameters.AddWithValue("@value1", customerid);
                command2.Parameters.AddWithValue("@Value2", custname);
                command2.Parameters.AddWithValue("@value3", address);
                command2.Parameters.AddWithValue("@value4", orderdate.SelectedDate);
                command2.Parameters.AddWithValue("@value5", number.Text);
                command2.Parameters.AddWithValue("@value6", StarterName);
                command2.Parameters.AddWithValue("@value7", MainName);
                command2.Parameters.AddWithValue("@value8", DessertName);
                command2.Parameters.AddWithValue("@value9", TotalPrice);

                try
                {

                    // updating stock

                    conn.Open();

                    command2.ExecuteNonQuery();

                    var command3 = new SqlCommand("SELECT IngredientID, Qty FROM CourseIngredients WHERE MealID = @id", conn);

                    command3.Parameters.AddWithValue("@id", Starter);

                    List<Tuple<string, int >> list123 = new List<Tuple<string, int>>();


                    var reader = command3.ExecuteReader();

                    while (reader.Read())
                    {

                        list123.Add(new Tuple<string, int>(reader.GetString(0), reader.GetInt32(1)));


                    }

                    reader.Close();

                    command3.Parameters.Clear();


                    command3.Parameters.AddWithValue("@id", Main);

                    reader = command3.ExecuteReader();

                    while (reader.Read())
                    {

                        list123.Add(new Tuple<string, int>(reader.GetString(0), reader.GetInt32(1)));


                    }

                    reader.Close();

                    command3.Parameters.Clear();


                    command3.Parameters.AddWithValue("@id", Dessert);

                    reader = command3.ExecuteReader();

                    while (reader.Read())
                    {

                        list123.Add(new Tuple<string, int>(reader.GetString(0), reader.GetInt32(1)));


                    }


                    reader.Close();


                    command3.CommandText = "UPDATE STOCK SET Qty = Qty - @qtydeduction WHERE StockID = @id";

                    foreach (var i in list123)
                    {
                        command3.Parameters.Clear();

                        command3.Parameters.AddWithValue("@id", i.Item1);
                        command3.Parameters.AddWithValue("@qtydeduction", i.Item2 * Convert.ToInt32(number.Text));


                        int n = command3.ExecuteNonQuery();

                        


                    }

                    MessageBox.Show("Stock Updated!");

                    this.Close();


                }

                catch (SqlException ex)
                {

                    MessageBox.Show("There is a problem with the Data Entered : Error Code : " + ex.Message);
                    return;

                }


               


               



            



            

                


            }

        }

        private void deliverycheckbox_Checked(object sender, RoutedEventArgs e)
        {
            

        }

        private void venue_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (deliverycheckbox.IsChecked == true)
            //{

            //    venue.IsReadOnly = false;

            //}

            //if (deliverycheckbox.IsChecked == false)
            //{
            //    venue.IsReadOnly = true;

            //    venue.Text = "This Order will be Collected";

            //}
        }

        private void deliverycheckbox_Click(object sender, RoutedEventArgs e)
        {
            if (deliverycheckbox.IsChecked == true)
            {

                venue.IsReadOnly = false;
                venue.Clear();

            }

            if (deliverycheckbox.IsChecked == false)
            {
                venue.IsReadOnly = true;

                venue.Text = "This Order will be Collected";

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                customerIDstat = CustomerList[customerCB.SelectedIndex].Item1;


                addCardDetailsForm addCard11 = new addCardDetailsForm();

                addCard11.ShowDialog();
            }

            catch
            {
                MessageBox.Show("No Customer Selected");

            }

            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void number_TextChanged(object sender, TextChangedEventArgs e) // number of people inputted
        {

            

        }
    }
}
