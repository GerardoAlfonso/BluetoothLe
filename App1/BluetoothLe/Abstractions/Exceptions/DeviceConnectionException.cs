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

namespace App1.BluetoothLe.Abstractions.Exceptions
{
    public class DeviceConnectionException : Exception
    {
        public Guid DeviceId { get; }
        public string DeviceName { get; }

        // TODO: maybe pass IDevice instead (after Connect refactoring)
        public DeviceConnectionException(Guid deviceId, string deviceName, string message) : base(message)
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
        }
    }
}