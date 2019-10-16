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
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace SolutionCW
{
    /// <summary>
    /// Interaction logic for Stock.xaml
    /// </summary>
    public partial class Stock : Page
    {
        public ObservableCollection<StockClass> StockList;


        public Stock()
        {
            InitializeComponent();

            StockList = new ObservableCollection<StockClass>();

            Loaded += (s, e) => loadStock();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) // Datagrid
        {

           


        }


        public void loadStock()
        {
            string SQLconn = MainWindow.DBconnection;
            string SQLcomm = string.Empty;

            using (SqlConnection conn = new SqlConnection(SQLconn))
            {
                conn.Open();

                SQLcomm = "SELECT StockID, Description, [Storage Type], Qty, [Min Qty], isFresh FROM STOCK";

                var cmd = new SqlCommand(SQLcomm, conn);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int ID = reader.GetInt32(0);
                    var Desc = reader.GetString(1);
                    var StorageType = reader.GetString(2);
                    int Qty = reader.GetInt32(3);
                    int MQty = reader.GetInt32(4);
                    Boolean fresh = reader.GetBoolean(5);
                    
                    

                    StockClass stock = new StockClass(ID, Desc, StorageType, Qty, MQty, fresh);

                    StockList.Add(stock);

                }

                STOCKDG.IsReadOnly = true;

                STOCKDG.ItemsSource = StockList;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddStock addStock = new AddStock(this);

            addStock.ShowDialog();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            // new connection string declared

            string connString2 = MainWindow.DBconnection;
            string cmdString2 = string.Empty;

            // opening a new Sql connection 

            try
            {

                using (SqlConnection connection = new SqlConnection(connString2))
                {


                    cmdString2 = ("UPDATE STOCK SET Description = @Value1, [Storage Type] = @value2, Qty = @value3, [Min Qty] = @value4, isfresh = @value5 WHERE StockID = @id");

                    SqlCommand comm = new SqlCommand(cmdString2, connection);
                    connection.Open();

                    foreach (var record in StockList)
                    {

                        comm.Parameters.Clear();
                        comm.Parameters.AddWithValue("@id", record.IDStock);
                        comm.Parameters.AddWithValue("@Value1", record.Description);
                        comm.Parameters.AddWithValue("@Value2", record.StorageType);
                        comm.Parameters.AddWithValue("@Value3", record.StockQty);
                        comm.Parameters.AddWithValue("@Value4", record.StockMinQty);
                        comm.Parameters.AddWithValue("@Value5", record.Fresh);
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
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Edit Mode Enabled");

            STOCKDG.IsReadOnly = false;
        }
    }
}






