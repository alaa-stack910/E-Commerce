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
    /// Interaction logic for ParoductsList.xaml
    /// </summary>
    public partial class ParoductsList : Page
    {
        ECommerceDBEntities context=new ECommerceDBEntities();  
        public ParoductsList(string sort, string category)
        {
            InitializeComponent();

            var product=context.Products.Where(g=>g.Category == category).ToList();
            if (sort == "Price")
            {
                dgproducts.ItemsSource=product.OrderBy(g=>g.Price).ToList();
            }
            else if (sort == "Quantity")
            {
                dgproducts.ItemsSource = product.OrderBy(g => g.Quantity).ToList();
            }

            dgproducts.SelectedItem = product;
        }

        private void searchclick(object sender, RoutedEventArgs e)
        {
            dgproducts.ItemsSource=context.Products.Where(g => g.Name.Contains(txtsearch.Text)).ToList();
        }
    }
}
