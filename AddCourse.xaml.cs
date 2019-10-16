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
    /// Interaction logic for AddCourse.xaml
    /// </summary>
    public partial class AddCourse : Window
    {
        public List<Tuple<int, string>> IngredientList;
        private int Meal;
        public CoursePage page;


        public AddCourse(CoursePage page)
        {
            this.page = page;

            InitializeComponent();



            addingredientsbtn.IsEnabled = false;

            // adds the courses into the combobox

            foreach (var item in Enum.GetValues(typeof(courses)))
            {
                courseCB.Items.Add(item);

            }


            // new Tuple

            IngredientList = new List<Tuple<int, string>>();


            // connection to add ingredients to combobox

            using (SqlConnection conn = new SqlConnection(MainWindow.DBconnection))
            {

                var SQLcomm = new SqlCommand("SELECT StockID, Description FROM STOCK", conn);
                conn.Open();
                var reader = SQLcomm.ExecuteReader();

                while (reader.Read())
                {
                    IngredientList.Add(new Tuple<int, string>(reader.GetInt32(0), reader.GetString(1)));
                }

                reader.Close();



            }

            ingredientCB.ItemsSource = from c in IngredientList select c.Item2;




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addcourse_Click(object sender, RoutedEventArgs e)
        {

            // data validation

            if (courseCB.Text == string.Empty)
            {
                MessageBox.Show("You have not Entered a Valid Course");
                return;
            }

            if (desc.Text == string.Empty)
            {
                MessageBox.Show("You have not entered a Valid Course Description");
                return;

            }

            if (price.Text == string.Empty)
            {
                MessageBox.Show("Please Enter a Price");
                return;

            }

            // adding the data entered to the database 


            int coursetype = Convert.ToInt32(courseCB.SelectedValue);

            using (var conn = new SqlConnection(MainWindow.DBconnection))
            {
                var command = new SqlCommand("INSERT INTO Courses (Description, Price, CourseNo) VALUES (@desc, @price, @courseNo)", conn);

                command.Parameters.AddWithValue("@desc", desc.Text);
                command.Parameters.AddWithValue("@price", price.Text);
                command.Parameters.AddWithValue("courseNo", coursetype);


                // try catch to avoid SQL exceptions

                try
                {
                    
                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Course sucessfully added. Please add Ingredients");
                    (sender as Button).IsEnabled = false;
                    addingredientsbtn.IsEnabled = true;
                    
                }


                catch(SqlException ex)
                {

                    MessageBox.Show("SQL Error: There has been an Issue with the Information you have entered. Have you used the Correct Data Input Formats?");

                }


                page.DessertList.Clear();
                page.LoadDesserts();




            }
        }

        private void addingredientsbtn_Click(object sender, RoutedEventArgs e)
        {
            // validation


            if(ingredientCB.Text == string.Empty)
            {
                MessageBox.Show("No Ingredient has been Selected.");
                return;
            }

            if(qty.Text == string.Empty)
            {
                MessageBox.Show("No Qty has been entered");
                return;
            }


            // SQL command that selects the last one added, (MAX used because the ID's are auto generated


            int ingredientID = IngredientList[ingredientCB.SelectedIndex].Item1;

            using (var conn = new SqlConnection(MainWindow.DBconnection))
            {

                conn.Open();

                var command = new SqlCommand("SELECT MAX(MealID) FROM Courses", conn);

                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Meal = reader.GetInt32(0);
                }

                reader.Close();
                conn.Close();


                // new command after reader close, Inserts the ingredients into the Tabel

                var command2 = new SqlCommand("INSERT INTO CourseIngredients (MealID, IngredientID, Qty) VALUES (@Id, @Ingredient, @Qty)", conn);

                

                command2.Parameters.AddWithValue("@Id", Meal);
                command2.Parameters.AddWithValue("@Ingredient", ingredientID);
                command2.Parameters.AddWithValue("@Qty", qty.Text);

                // try catch to avoid exceptions that will break the code

                try
                {
                    conn.Open();

                    command2.ExecuteNonQuery();

                    conn.Close();

                    // remove the stock from the combobox to ensure duplicates arent entered

                    IngredientList.Remove((from i in IngredientList where i.Item2.ToString() == ingredientCB.SelectedItem.ToString() select i).Single());
                    ingredientCB.ItemsSource = from i in IngredientList select i.Item2;
                    qty.Clear();
                    MessageBox.Show("You have sucessfully added an Ingredient. You will be not be able to add this ingredient again.");

                    if (ingredientCB.HasItems == false)
                    {

                        MessageBox.Show("You have added all Ingredients you have in Stock.");
                        addingredientsbtn.IsEnabled = false;

                    }
                }

                catch(SqlException ex)
                {

                    MessageBox.Show(ex.Message);


                }

                

            }




        }
    }
}
