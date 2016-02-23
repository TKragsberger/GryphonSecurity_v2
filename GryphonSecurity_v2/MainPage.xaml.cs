using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GryphonSecurity_v2.Domain;

namespace GryphonSecurity
{
    public partial class MainPage : PhoneApplicationPage
    {
        Controller controller = Controller.Instance;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();


        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (controller.getStartup())
            {
                controller.startUp();
                //her mike få denne ændring
                NavigationService.Navigate(new Uri("/LoginLayout.xaml", UriKind.Relative));
            }
        }



        private void scanNFCButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ScanNFCLayout.xaml", UriKind.Relative));
        }

        private void alarmReportButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AlarmRapportLayout.xaml", UriKind.Relative));
        }
        private void loadup()
        {
            NavigationService.Navigate(new Uri("/LoginLayout.xaml", UriKind.Relative));
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}