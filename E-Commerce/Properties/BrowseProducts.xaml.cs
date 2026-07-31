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

namespace E_Commerce.Properties
{
    /// <summary>
    /// Interaction logic for BrowseProducts.xaml
    /// </summary>
    public partial class BrowseProducts : Page
    {

        public BrowseProducts()
        {
            InitializeComponent();
        }

        private void filterclick(object sender, RoutedEventArgs e)
        {
            string category = (cmcategory.SelectedItem as ComboBoxItem).Content.ToString();
            string sort="";
            if (raPrice.IsChecked == true)
            {
                sort = "Price";
            }
            else if (raQuantity.IsChecked == true)
            {
                sort = "Quantity";
            
            }

            NavigationService.Navigate(new ParoductsList(sort,category));
        }
    }
    //iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii
}
