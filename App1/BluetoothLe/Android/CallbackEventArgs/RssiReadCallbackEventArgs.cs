using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * using System;
using Android.Bluetooth;
using Plugin.BLE.Abstractions.Contracts;
*/

namespace App1.BluetoothLe.Android.CallbackEventArgs
{
    public class RssiReadCallbackEventArgs : EventArgs
    {
        public Exception Error { get; }
        public int Rssi { get; }

        public RssiReadCallbackEventArgs(Exception error, int rssi)
        {
            Error = error;
            Rssi = rssi;
        }
    }
}