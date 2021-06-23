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
    /// Specifies how a value should be written.
    /// </summary>
    public enum CharacteristicWriteType
    {
        /// <summary>
        /// Value should be written with response if supported, else without response.
        /// </summary>
        Default,

        /// <summary>
        /// Value should be written with response.
        /// </summary>
        WithResponse,

        /// <summary>
        /// Value should be written without response.
        /// </summary>
        WithoutResponse
    }
}