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
    public partial class LoginLayout : PhoneApplicationPage
    {

        Controller controller = Controller.Instance;
        public LoginLayout()
        {
            InitializeComponent();

            //String lastName = textBoxLastname.Text;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            TextBox t = (TextBox)textBoxUsername;
            String username = t.Text;
            TextBox t2 = (TextBox)textBoxPassword;
            String password = t2.Text;
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            //User user = controller.getUser();
            //if (username.Contains(user.Username) && password.Contains(user.Password))
            //{
            //    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            //    try
            //    {
            //        controller.login(username, password);

            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show(AppResources.LoginError);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show(AppResources.UsernamePasswordError);
            //}
        }

        private void registereButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/RegisterLayout.xaml", UriKind.Relative));

        }
    }
}