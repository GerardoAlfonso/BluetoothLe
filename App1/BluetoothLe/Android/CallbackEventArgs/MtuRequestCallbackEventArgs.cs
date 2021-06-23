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
using Plugin.BLE.Abstractions.Contracts;
*/

namespace App1.BluetoothLe.Android.CallbackEventArgs
{
    public class MtuRequestCallbackEventArgs : EventArgs
    {
        public Exception Error { get; }
        public int Mtu { get; }

        public MtuRequestCallbackEventArgs(Exception error, int mtu)
        {
            Error = error;
            Mtu = mtu;
        }
    }
}