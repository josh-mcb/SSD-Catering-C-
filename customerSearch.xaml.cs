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
    /// Interaction logic for customerSearch.xaml
    /// </summary>
    public partial class customerSearch : Window
    {

        Customer parent;


        public customerSearch(Customer page)
        {
            InitializeComponent();
            parent = page;
        }

        public void searchName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public string returnText()
        {

            return searchName.Text;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string SearchInput = searchName.Text;

            parent.searchQuery(SearchInput);

            this.Close();
        }
    }
}
