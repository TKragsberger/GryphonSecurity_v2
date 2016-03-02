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
using Windows.Storage.Streams;
using System.Runtime.InteropServices.WindowsRuntime;
using NdefLibrary.Ndef;
using System.Text;
using GryphonSecurity;

namespace GryphonSecurity_v2
{
    public partial class ScanNFCLayout : PhoneApplicationPage
    {

        Controller controller = Controller.Instance;
       // private Windows.Networking.Proximity.ProximityDevice device;
        public ScanNFCLayout()
        {
            InitializeComponent();
            //initializeProximitySample();
        }

        private void scanButton_Click(object sender, RoutedEventArgs e)
        {

            controller.scanNFCTag();
            
            //  Debug.WriteLine("Published Message. ID is {0}", Id);
        }


        }
        //private void messageReceived(ProximityDevice sender, ProximityMessage message)
        //{
        //    Debug.WriteLine("Der sker noget");

        //    //var buffer = message.Data.ToArray();
            
        //    var buffer = DataReader.FromBuffer(message.Data);
        //    Debug.WriteLine("1: " + buffer.ReadByte());
        //    Debug.WriteLine("2: " + buffer.ReadByte());
        //    int payloadLength = buffer.ReadByte();
        //    Debug.WriteLine("5: " + buffer.ReadByte());
        //    Debug.WriteLine("jaja length: " + payloadLength);
        //    var payload = new byte[payloadLength];
        //    Debug.WriteLine("3: " + payload);

        //    buffer.ReadBytes(payload);
                      
        //    var langLen = (byte)(payload[0] & 0x3f);
        //    Debug.WriteLine("LanLeng: " + langLen);
        //    var textLeng = payload.Length - 1 - langLen;
        //    var textBuf = new byte[textLeng];
        //    System.Buffer.BlockCopy(payload, 1+langLen, textBuf, 0, textLeng);
        //    //var messageType = Encoding.UTF8.GetString(buffer, 0, mimesize);
        //    //Debug.WriteLine("Buffer: " + buffer + "buffer length: " + buffer.Length);
        //    var scanned_message = Encoding.UTF8.GetString(textBuf, 0, textBuf.Length);



        //    Dispatcher.BeginInvoke(() =>
        //    {
                
        //        Debug.WriteLine("Tekst: " + scanned_message);
        //        textBlockTest.Text = scanned_message;




        //    });

           
             
        //}

        //private void initializeProximitySample()
        //{

        //    device = Windows.Networking.Proximity.ProximityDevice.GetDefault();
        //    if (device == null)
        //        Debug.WriteLine("Failed to initialized proximity device.\n" +
        //                         "Your device may not have proximity hardware.");

        //}
    }
}