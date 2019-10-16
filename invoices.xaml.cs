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
    /// Interaction logic for invoices.xaml
    /// </summary>
    public partial class invoices : Page
    {
        private ObservableCollection<invoice> invoiceList;


        public invoices()
        {
            InitializeComponent();

            invoiceList = new ObservableCollection<invoice>();


        }


        public void LoadInvoice()
        {
            
                string SQLconn = MainWindow.DBconnection;
                string SQLcomm = string.Empty;

            using (SqlConnection conn = new SqlConnection(SQLconn))
            {
                conn.Open();

                SQLcomm = "SELECT InvoiceID, OrderID, CustomerID, OrderDate, Qty, Starter, Main, Dessert, Total FROM Invoice";

                var command = new SqlCommand(SQLcomm, conn);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int invoiceID = reader.GetInt32(0);
                    int OrderID = reader.GetInt32(1);
                    int cust = reader.GetInt32(2);
                    DateTime date = reader.GetDateTime(3);
                    int qty = reader.GetInt32(4);
                    string Starter = reader.GetString(5);
                    string Main = reader.GetString(6);
                    string dessert = reader.GetString(7);
                    decimal total = reader.GetDecimal(8);


                }

            }


        }









        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e) // print
        {
            printinvoice printinvoice = new printinvoice();

            printinvoice.ShowDialog();
        }
    }
}
