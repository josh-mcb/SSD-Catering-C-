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
    /// Interaction logic for addCardDetailsForm.xaml
    /// </summary>
    public partial class addCardDetailsForm : Window
    {
        public bool cardAdded { get; private set; }

        public addCardDetailsForm()
        {
            InitializeComponent();

            custIDbox.IsReadOnly = true;

            custIDbox.Text = Convert.ToString(NewOrder.customerIDstat);




        }


        

        private void custIDbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //custIDbox.IsReadOnly = true;

            //custIDbox.Text = Convert.ToString(NewOrder.customerIDstat);
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Add Card Button
        {

            string card = cardnumber.Text;


            if(card == "" || card.Length !=25)
            {
                MessageBox.Show("Invalid Card Number Entered");
                return;

            }

            if(cvcBox.Text == "")
            {
                MessageBox.Show("Invalid CVC Number");
                return;
            }

           if(carddate.Text == "")
            {

                MessageBox.Show("Invalid Display Date");
                return;

            }
                

            
        

           

            using (var conn = new SqlConnection(MainWindow.DBconnection))
            {
                var command = new SqlCommand("INSERT INTO CardDetails (CustomerID, [Card Number], CVC, ExpDate) VALUES (@id, @cardnum, @cvc, @date)", conn);

                command.Parameters.AddWithValue("@id", custIDbox.Text);
                command.Parameters.AddWithValue("@cardnum", cardnumber.Text);
                command.Parameters.AddWithValue("@cvc", cvcBox.Text);
                command.Parameters.AddWithValue("@date", carddate.DisplayDate);


                try
                {

                    conn.Open();
                    MessageBox.Show("Card Added");
                    command.ExecuteNonQuery();

                }

                catch(SqlException ex)
                {

                    MessageBox.Show("There has been a problem with the Card Details");

                }


            }
            cardAdded = true;
            this.Close();

            


        }
    }
}
