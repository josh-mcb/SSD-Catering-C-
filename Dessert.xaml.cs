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
    /// Interaction logic for Dessert.xaml
    /// </summary>
    public partial class CoursePage : Page
    {
       public ObservableCollection<CourseClass> DessertList;


        public CoursePage()
        {
            InitializeComponent();
            DessertList = new ObservableCollection<CourseClass>();
            Loaded += (s, e) => LoadDesserts();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadDesserts();
            dataGriddg.ItemsSource = DessertList;
        }

        public void LoadDesserts()
        {
            string SQLconn = MainWindow.DBconnection;
            string SQLcomm = string.Empty;

            using (SqlConnection conn = new SqlConnection(SQLconn))
            {
                conn.Open();

                SQLcomm = "SELECT MealID, Description, Price, CourseNo FROM Courses";

                var command = new SqlCommand(SQLcomm, conn);

                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    int ID = reader.GetInt32(0);
                    var Desc = reader.GetString(1);
                    decimal price = reader.GetDecimal(2);
                    courses course = (courses)reader.GetInt32(3);


                    CourseClass dessert = new CourseClass(ID, Desc, price, course);

                    DessertList.Add(dessert);
                    
                }



                dataGriddg.IsReadOnly = true;

               dataGriddg.ItemsSource = DessertList;

                conn.Close();


            }



        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddCourse addCourse = new AddCourse(this);

            addCourse.ShowDialog();
        }
    }
}
