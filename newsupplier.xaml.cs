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
    /// Interaction logic for newsupplier.xaml
    /// </summary>
    public partial class newsupplier : Window
    {
        public newsupplier()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(name.Text == string.Empty)
            {
                MessageBox.Show("No Name has been entered");
                return;
            }

            if(address.Text == string.Empty)
            {
                MessageBox.Show("No Address has been entered");
                return;
            }

            if(phone.Text == string.Empty || phone.Text.Contains("qwertyuiopasdfghjklzxcvbnm"))
            {
                MessageBox.Show("Problems with Data entered in the Phone Box");
                return;
            }

            if(mail.Text == string.Empty)
            {

                MessageBox.Show("No Mail entered");
                return;
            }




            using (var conn = new SqlConnection(MainWindow.DBconnection))
            {
                var command = new SqlCommand("INSERT INTO Supplier (SupplierName, Address, Phone, Email) VALUES (@name, @address, @phone, @mail)", conn);

                command.Parameters.AddWithValue("@name", name.Text);
                command.Parameters.AddWithValue("@address", address.Text);
                command.Parameters.AddWithValue("@phone", phone.Text);
                command.Parameters.AddWithValue("@mail", mail.Text);


                // try catch to avoid SQL exceptions

                try
                {

                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Supplier sucessfully added");
                    this.Close();
                }



                catch
                {


                       MessageBox.Show("SQL Error: There has been an Issue with the Information you have entered. Have you used the Correct Data Input Formats?");

                }
            }
        }
    }
}
