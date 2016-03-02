using GryphonSecurity_v2.DataSource;
using GryphonSecurity_v2.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Windows.Devices.Geolocation;
using Windows.Networking.Proximity;
using Windows.Storage.Streams;

namespace GryphonSecurity
{
    class Controller
    {
        private Windows.Networking.Proximity.ProximityDevice device;
        private DBFacade dBFacade;
        Boolean startup = true;
        GeoCoordinate presentCoordinate;
        GeoCoordinate targetCoordinates;
        private double checker;


        private static Controller instance;
        private Controller()
        {
            dBFacade = new DBFacade();
        }
        public static Controller Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Controller();
                }
                return instance;
            }
        }
        public void login(String userName, String password)
        {
            dBFacade.login(userName, password);
        }
        public void startUp()
        {
            startup = false;
        }
        public Boolean getStartup()
        {
            return startup;
        }
        public Boolean createUser(User user)
        {
            return dBFacade.createUser(user);
        }

        public User getUser()
        {
            return dBFacade.getUser();
        }

        public Boolean createAlarmReport(AlarmReport alarmReport)
        {
            return dBFacade.createAlarmReport(alarmReport);
        }

        public void scanNFCTag()
        {
            Boolean moveOn = initializeProximitySample();
            if(moveOn == true)
            {
               
                device.SubscribeForMessage("NDEF", messageReceived);
              
            }

        else
            {

            }
        }
        
        private Boolean initializeProximitySample()
        {
            Boolean deviceProxomity = true;
            device = Windows.Networking.Proximity.ProximityDevice.GetDefault();
            if (device == null)
            {
                Debug.WriteLine("Failed to initialized proximity device.\n" +
                                 "Your device may not have proximity hardware.");
                deviceProxomity = false;
            }
            return deviceProxomity;
            
        }

        private void messageReceived(ProximityDevice sender, ProximityMessage message)
        {
            Debug.WriteLine("Der sker noget");

            //var buffer = message.Data.ToArray();

            var buffer = DataReader.FromBuffer(message.Data);
            Debug.WriteLine("1: " + buffer.ReadByte());
            Debug.WriteLine("2: " + buffer.ReadByte());
            int payloadLength = buffer.ReadByte();
            Debug.WriteLine("5: " + buffer.ReadByte());
            Debug.WriteLine("jaja length: " + payloadLength);
            var payload = new byte[payloadLength];
            Debug.WriteLine("3: " + payload);

            buffer.ReadBytes(payload);

            var langLen = (byte)(payload[0] & 0x3f);
            Debug.WriteLine("LanLeng: " + langLen);
            var textLeng = payload.Length - 1 - langLen;
            var textBuf = new byte[textLeng];
            System.Buffer.BlockCopy(payload, 1 + langLen, textBuf, 0, textLeng);
            //var messageType = Encoding.UTF8.GetString(buffer, 0, mimesize);
            //Debug.WriteLine("Buffer: " + buffer + "buffer length: " + buffer.Length);
            var scanned_message = Encoding.UTF8.GetString(textBuf, 0, textBuf.Length);

            Debug.WriteLine("Tekst: " + scanned_message);

            canUseGPS();
            getDistance();
            
            //Dispatcher.BeginInvoke(() =>
            //{

            //    Debug.WriteLine("Tekst: " + scanned_message);
            //    //textBlockTest.Text = scanned_message;




            //});



        }
        public void canUseGPS()
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
        public async Task<GeoCoordinate> onLocationScan() {

            

            if ((bool)IsolatedStorageSettings.ApplicationSettings["LocationConsent"] != true)
            {
                // The user has opted out of Location.
                
            }

            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10)
                    );

                
                double latitude = geoposition.Coordinate.Point.Position.Latitude;
                double longitude = geoposition.Coordinate.Point.Position.Longitude;
                presentCoordinate = new GeoCoordinate(latitude, longitude);
                Debug.WriteLine("PresentCoordinate: " + presentCoordinate);

            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x80004004)
                {
                    // the application does not have the right capability or the location master switch is off
                    Debug.WriteLine( "location  is disabled in phone settings.");
                }
            }
            return presentCoordinate;
            
        }

        public async void getDistance() {
            targetCoordinates = new GeoCoordinate(55, 12);
            presentCoordinate = await onLocationScan();
            double distance = targetCoordinates.GetDistanceTo(presentCoordinate);
            checker = distance;
            Debug.WriteLine("Distance: " + distance);
            if (checker > 500)
            {
                Debug.WriteLine("Stop cheating!");
            }
            else
            {
                Debug.WriteLine("Good boi!");
            }
           
          
        }

    }
}
