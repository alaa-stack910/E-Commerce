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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        ECommerceDBEntities context = new ECommerceDBEntities();
        Product selected = new Product();
        User user = new User();
        public Home()
        {
            InitializeComponent();
            loadproducts();
        }

        private void loadproducts()
        {

            dgproducts.ItemsSource=context.Products.ToList();

        }

        private void addclick(object sender, RoutedEventArgs e)
        {
            Product p=new Product();
            p.Name=txtname.Text;
            p.Quantity=int.Parse(txtQuantity.Text);
            p.Description=txtDescription.Text;
            p.Category=txtCategory.Text;
            p.Price=decimal.Parse(txtPrice.Text);
            context.Products.Add(p);
            context.SaveChanges();

        }

        private void reloadclick(object sender, RoutedEventArgs e)
        {
            loadproducts();
        }

        private void updateclick(object sender, RoutedEventArgs e)
        {
            if (selected == null)
            {
                return;
            }
            selected.Name=txtname.Text;
            selected.Price=decimal.Parse(txtPrice.Text);
            selected.Description=txtDescription.Text;
            selected.Category=txtCategory.Text;
            selected.Quantity=int.Parse(txtQuantity.Text);
            context.SaveChanges();
        }


        private void removeclick(object sender, RoutedEventArgs e)
        {
            if (selected == null)
            {
                return;
            }
            context.Products.Remove(selected);
            context.SaveChanges();
        }

        private void dgproducts_selection(object sender, SelectionChangedEventArgs e)
        {
            if (dgproducts.SelectedItem == null)
            {
                return;
            }
            selected=dgproducts.SelectedItem as Product;
            if (selected != null)
            {
                txtQuantity.Text = selected.Quantity.ToString();
                txtDescription.Text = selected.Description;
                txtname.Text = selected.Name;
                txtPrice.Text = selected.Price.ToString();
                txtid.Text = selected.Id.ToString();
                txtCategory.Text = selected.Category;
            }
        }
        private  void searchclick(object sender, RoutedEventArgs e)
        {
            dgproducts.ItemsSource=context.Products.Where(v=>v.Name.Contains(txtsearch.Text)).ToList();
        }

        private void viewclick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new View(selected));
        }

        private void browseclick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BrowseProducts());
        }

    }
}
