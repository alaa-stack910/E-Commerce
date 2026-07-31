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
using System.Data.Entity;
namespace E_Commerce.Properties
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        ECommerceDBEntities context=new ECommerceDBEntities();
        User user;
        public Login()
        {
            InitializeComponent();
        }

        private void homeclick(object sender, RoutedEventArgs e)
        {
            string name=txtusename.Text.Trim();
            string password=txtPassword.Password.Trim();

            if (name == "")
            {
                MessageBox.Show("Enter username");
                return;
            }

            if (password == "")
            {
                MessageBox.Show("Enter password");
                return;
            }

            user=context.Users.FirstOrDefault(m=>m.FullName==name && m.Password==password);


            if (user == null)
            {
                return;

            }

            if (user.Role == "Guest")
            {
                NavigationService.Navigate(new Guest());
            }

            else if(user.Role == "Customer")
            {
                NavigationService.Navigate(new Home());
            }
        }
    }
}
