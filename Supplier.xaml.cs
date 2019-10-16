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
    /// Interaction logic for Supplier.xaml
    /// </summary>
    public partial class Supplier : Page
    {

        ObservableCollection<SupplierClass> SupplierCollection;

        public Supplier()
        {
            SupplierCollection = new ObservableCollection<SupplierClass>();

            InitializeComponent();

            Loaded += (s, e) => LoadCustomers();


        }


        public void LoadCustomers()
        {

            string SQLconn = MainWindow.DBconnection;
            string SQLcomm = string.Empty;

            using (SqlConnection conn = new SqlConnection(SQLconn))
            {
                conn.Open();

                SQLcomm = "SELECT SupplierID, SupplierName, Address, Phone, Email FROM Supplier";

                var command = new SqlCommand(SQLcomm, conn);

                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    int ID = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string address = reader.GetString(2);
                    string phone = reader.GetString(3);
                    string email = reader.GetString(4);

                    SupplierClass supplier = new SupplierClass(ID, name, address, phone, email);

                    SupplierCollection.Add(supplier);
                }

                supplierdg.ItemsSource = SupplierCollection;



            }






            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            newsupplier newsupplier = new newsupplier();

            newsupplier.ShowDialog();
        }
    }
}
