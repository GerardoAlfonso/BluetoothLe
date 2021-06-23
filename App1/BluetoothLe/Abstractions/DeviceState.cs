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

namespace App1.BluetoothLe.Abstractions
{
    /// <summary>
    /// Determines the connection state of the device.
    /// </summary>
	public enum DeviceState
    {
        /// <summary>
        /// Device is disconnected.
        /// </summary>
        Disconnected,

        /// <summary>
        /// Device is connecting.
        /// </summary>
        Connecting,

        /// <summary>
        /// Device is connected.
        /// </summary>
        Connected,

        /// <summary>
        /// OnAndroid: Device is connected to the system. In order to use this device please call connect it by using the Adapter. 
        /// </summary>
        Limited
    }
}