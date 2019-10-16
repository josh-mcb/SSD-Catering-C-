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
using System.Printing;
using System.Data.SqlClient;







namespace SolutionCW
{
    /// <summary>
    /// Interaction logic for printinvoice.xaml
    /// </summary>
    public partial class printinvoice : Window
    {
        



        public List<Tuple<int, string, string, DateTime, string, decimal>> list;




        public printinvoice()
        {

            list = new List<Tuple<int, string, string, DateTime, string, decimal>>();

            InitializeComponent();

            using (SqlConnection conn = new SqlConnection(MainWindow.DBconnection))
            {

                var SQLcomm = new SqlCommand("SELECT InvoiceID, Name, Address, OrderDate, Qty, Total FROM Invoice", conn);
                conn.Open();
                var reader = SQLcomm.ExecuteReader();


                while (reader.Read())
                {

                    int i = reader.GetInt32(0);
                    string c = reader.GetString(1);
                    string d = reader.GetString(2);
                    DateTime e = Convert.ToDateTime(reader.GetDateTime(3));
                    var f = reader.GetString(4);
                    decimal v = (decimal)reader.GetDecimal(5);

                    list.Add(new Tuple<int, string, string, DateTime, string, decimal>(i, c, d, e, f, v));
                }

                invoiceCB.ItemsSource = from c in list select c.Item1 + " " + c.Item2;

                invoiceCB.SelectionChanged += (s, e) =>
                {
                    if (invoiceCB.SelectedIndex > -1)
                    {
                        var invoiceno = list[invoiceCB.SelectedIndex].Item1;
                        var Name = list[invoiceCB.SelectedIndex].Item2;
                        var Address = list[invoiceCB.SelectedIndex].Item3;
                        var orderDate = list[invoiceCB.SelectedIndex].Item4;
                        var total = list[invoiceCB.SelectedIndex].Item6;

                        invoicetb.Text = Convert.ToString(invoiceno);
                        nametb.Text = Name;
                        addresstb.Text = Address;
                        dateselecter.SelectedDate = orderDate;
                        totalcb.Text = Convert.ToString(total);

                    }
                };



            }





        }

            private void printbtn_Click(object sender, RoutedEventArgs e)
            {


            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true)
            {
                print.PrintVisual(invoiceCANVAS, "Invoice");

            }


            }

        private void nametb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
