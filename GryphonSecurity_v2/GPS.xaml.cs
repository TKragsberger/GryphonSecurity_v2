using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using System.IO.IsolatedStorage;
using System.Device.Location;
using Microsoft.Phone.Maps.Services;
using GryphonSecurity_v2.Resources;
using System.Diagnostics;

namespace GryphonSecurity_v2
{
    public partial class GPS : PhoneApplicationPage
    {
        GeoCoordinate presentCoordinate;
        GeoCoordinate targetCoordinates;
    
        public GPS()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains("LocationConsent"))
            {
                // User has opted in or out of Location
                return;
            }
            else
            {
                MessageBoxResult result =
                    MessageBox.Show("This app accesses your phone's location. Is that ok?",
                    "Location",
                    MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.OK)
                {
                    IsolatedStorageSettings.ApplicationSettings["LocationConsent"] = true;
                }
                else
                {
                    IsolatedStorageSettings.ApplicationSettings["LocationConsent"] = false;
                }

                IsolatedStorageSettings.ApplicationSettings.Save();
            }
        }

        private async void OneShotLocation_Click(object sender, RoutedEventArgs e)
        {

            if ((bool)IsolatedStorageSettings.ApplicationSettings["LocationConsent"] != true)
            {
                // The user has opted out of Location.
                return;
            }

            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10)
                    );

                LatitudeTextBlock.Text = geoposition.Coordinate.Point.Position.Latitude.ToString("0.00");
                LongitudeTextBlock.Text = geoposition.Coordinate.Point.Position.Longitude.ToString("0.00");
                double latitude = geoposition.Coordinate.Point.Position.Latitude;
                double longitude = geoposition.Coordinate.Point.Position.Longitude;
                presentCoordinate = new GeoCoordinate(latitude, longitude);

            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x80004004)
                {
                    // the application does not have the right capability or the location master switch is off
                    StatusTextBlock.Text = "location  is disabled in phone settings.";
                }
            }
        }

        private void FindData_Click(object sender, RoutedEventArgs e)
        {
            GetPosition();
        }

        public void GetPosition()
        {
            var latitude = 0d;
            var longitude = 0d;
            var locator = new Geolocator();
            var geocodequery = new GeocodeQuery();


            if (!locator.LocationStatus.Equals(PositionStatus.Disabled))
            {
                geocodequery.GeoCoordinate = new GeoCoordinate(0, 0);
                geocodequery.SearchTerm = Address.Text+ "Denmark";
                geocodequery.QueryAsync();


                geocodequery.QueryCompleted += (sender, args) =>
                {
                    if (!args.Result.Equals(null))
                    {
                        var result = args.Result.FirstOrDefault();
                        latitude = result.GeoCoordinate.Latitude;
                        Debug.WriteLine("Latitude: " + latitude);
                        longitude = result.GeoCoordinate.Longitude;
                        Debug.WriteLine("Longitude: " + longitude);
                        LatitudeTextBlockFromAddress.Text = latitude + "";
                        LongitudeTextBlockFromAddress.Text = longitude + "";
                        targetCoordinates = new GeoCoordinate(latitude, longitude);
                       
                    }
                };
            }

            else
            {
                MessageBox.Show("Service Geolocation not enabled!", AppResources.ApplicationTitle, MessageBoxButton.OK);

                return;
            }
        }

        private void GetDistance_Click(object sender, RoutedEventArgs e)
        {
            Distance.Text = targetCoordinates.GetDistanceTo(presentCoordinate)+"";
        }
    }
}