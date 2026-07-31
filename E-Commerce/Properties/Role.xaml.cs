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
    /// Interaction logic for Role.xaml
    /// </summary>
    public partial class Role : Page
    {
        ECommerceDBEntities context=new ECommerceDBEntities();
        public Role()
        {
            InitializeComponent();
        }


        private void signclick(object sender, RoutedEventArgs e)
            
        {
            if (racustomer.IsChecked == true)
            {
                NavigationService.Navigate(new Login());
            }
            else if(raguest.IsChecked == true)
            {
                NavigationService.Navigate(new Guest());   
            }
        }

        private void loginclick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }
    }
}
