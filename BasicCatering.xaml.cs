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

namespace SolutionCW
{
    /// <summary>
    /// Interaction logic for BasicCatering.xaml
    /// </summary>
    public partial class BasicCatering : Window
    {
        public BasicCatering()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // customer 
        {
            BSframe.Source = new Uri("Customer.xaml", UriKind.RelativeOrAbsolute);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // Stock
        {
            BSframe.Source = new Uri("Stock.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Button_Click_Order(object sender, RoutedEventArgs e)
        {
            BSframe.Source = new Uri("Order.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Button_Click_Dessert(object sender, RoutedEventArgs e)
        {
            BSframe.Source = new Uri("Dessert.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Button_Click_Supplier(object sender, RoutedEventArgs e)
        {
            BSframe.Source = new Uri("Supplier.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Button_Click_Invoices(object sender, RoutedEventArgs e)
        {
            printinvoice printinvoice = new printinvoice();

            printinvoice.ShowDialog();
        }

        private void BSframe_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void Button_Click_customer(object sender, RoutedEventArgs e)
        {
            BSframe.Source = new Uri("Customer.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Button_Click_100(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You are not permitted to access these Details");
        }
    }
}
