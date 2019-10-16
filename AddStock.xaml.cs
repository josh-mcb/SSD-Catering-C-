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
    /// Interaction logic for AddStock.xaml
    /// </summary>
    public partial class AddStock : Window
    {
        public Stock stock;


        public AddStock(Stock stock)
        {
            this.stock = stock;

            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        

        private void addstock_tb_Click(object sender, RoutedEventArgs e)
        {

           
            string connString = MainWindow.DBconnection;

            string cmdString = "INSERT INTO STOCK(Description, [Storage Type],  Qty, [Min Qty], isFresh) VALUES (@desc, @storage, @Qty, @mQty, @fresh)";

            if(description_tb.Text == string.Empty)
            {
                MessageBox.Show("No Description Entered");
                return;
            }

            if(qty_tb.Text == string.Empty || qty_tb.Text.Contains("qwertyuiopasdfghjklzxcvbnm"))
            {
                MessageBox.Show("No Qty Entered or Wrong Format Entered");
                return;
            }

            if (minstock_tb.Text == string.Empty || minstock_tb.Text.Contains("qwertyuiopasdfghjklzxcvbnm"))
            {
                MessageBox.Show("No Min Qty Entered or Wrong Format Entered");
                return;
            }


            if(storage_tb.Text == string.Empty)
            {

                MessageBox.Show("No Storage Entered");

            }


        


            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandText = cmdString;
                    comm.Parameters.AddWithValue("@desc", description_tb.Text);
                    comm.Parameters.AddWithValue("@storage", storage_tb.Text);
                    comm.Parameters.AddWithValue("@Qty", qty_tb.Text);
                    comm.Parameters.AddWithValue("@mQty", minstock_tb.Text);
                    comm.Parameters.AddWithValue("@fresh", fresh_check.IsChecked);


                    try
                    {

                        conn.Open();
                        comm.ExecuteNonQuery();
                        MessageBox.Show("Sucessfully added");

                        this.Close();

                        conn.Close();

                    }


                    catch(SqlException x)
                    {
                        MessageBox.Show("Error: " + x.Message);
                    }
                }

                stock.StockList.Clear();
                stock.loadStock();

                    
                
            }
        }

        private void fresh_check_Checked(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
