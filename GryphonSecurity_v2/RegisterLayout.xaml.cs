using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GryphonSecurity;
using GryphonSecurity_v2.Resources;
using GryphonSecurity_v2.Domain.Entity;

namespace GryphonSecurity_v2
{
    public partial class RegisterLayout : PhoneApplicationPage
    {
        Controller controller = Controller.Instance;
        public RegisterLayout()
        {
            InitializeComponent();
        }

        private void RegistrerBrugerButton_Click(object sender, RoutedEventArgs e)
        {
            String firstname = textBoxFirstname.Text;
            String lastname = textBoxLastName.Text;
            String address = textBoxAddress.Text;
            long phonenumber = Convert.ToInt64(textBoxPhonenumber.Text);
            String username = textBoxUsername.Text;
            String password = textBoxPassword.Text;
            String passwordConfirm = textBoxPasswordConfirm.Text;
            if (password.Equals(passwordConfirm))
            {
                try
                {
                    User user = new User(firstname, lastname, address, phonenumber, username, password);
                    if (controller.createUser(user))
                    {
                        MessageBox.Show(AppResources.UserCreated);
                        NavigationService.Navigate(new Uri("/LoginLayout.xaml", UriKind.Relative));
                    }
                    else
                    {
                        MessageBox.Show(AppResources.UserNotCreated);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show(AppResources.UserRegitrationError);
                }
            }
            else
            {
                MessageBox.Show(AppResources.UserPasswordNotEquel);
            }
        }
    }
}