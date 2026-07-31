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
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Page
    {
        ECommerceDBEntities context=new ECommerceDBEntities();
        User user=new User();
        public Signup()
        {
            InitializeComponent();
        }


        private void homeclick(object sender, RoutedEventArgs e)
        {
            string name = txtusename.Text.Trim();
            string email = txtemail.Text.Trim();
            string password=txtPassword.Password.Trim();
            string confirm = txtConfirm.Password.Trim();


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
            if (confirm == "")
            {
                MessageBox.Show("Enter password confirm");
                return;
            }
            if (email == "")
            {
                MessageBox.Show("Enter email");
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("password not the same");
                return;


            }
            bool found=context.Users.Any(v=>v.Email == email);
            if (found == true)
            {
                MessageBox.Show("this is email already exist");
                return;

            }
            user.Email=email;
            user.FullName=name;
            user.Password=password;
            user.Role = "Customer";

            context.Users.Add(user);
            context.SaveChanges();

            NavigationService.Navigate(new Home());

        }
    }
}
