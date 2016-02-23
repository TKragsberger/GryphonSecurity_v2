using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Networking.Proximity;
using System.Diagnostics;

namespace GryphonSecurity_v2
{
    public partial class ScanNFCLayout : PhoneApplicationPage
    {
        private Windows.Networking.Proximity.ProximityDevice device;
        public ScanNFCLayout()
        {
            InitializeComponent();
            initializeProximitySample();
        }

        private void scanButton_Click(object sender, RoutedEventArgs e)
        {


            device.SubscribeForMessage("NDEF", messageReceived);
            //  Debug.WriteLine("Published Message. ID is {0}", Id);


        }
        private void messageReceived(ProximityDevice sender, ProximityMessage message)
        {

            //textBlockTest.Text += "message modetaget: " + message.DataAsString;
            //  Debug.WriteLine("Received from {0}:'{1}'", sender.DeviceId, message.DataAsString);
        }

        private void initializeProximitySample()
        {

            device = Windows.Networking.Proximity.ProximityDevice.GetDefault();
            if (device == null)
                Debug.WriteLine("Failed to initialized proximity device.\n" +
                                 "Your device may not have proximity hardware.");

        }
    }
}