using System;
using Android.Bluetooth;
using App1.BluetoothLe.Abstractions.Exceptions;


namespace App1.BluetoothLe.Android.CallbackEventArgs
{
    public class DescriptorCallbackEventArgs
    {
        public BluetoothGattDescriptor Descriptor { get; }
        public Exception Exception { get; }

        public DescriptorCallbackEventArgs(BluetoothGattDescriptor descriptor, Exception exception = null)
        {
            Descriptor = descriptor;
            Exception = exception;
        }
    }
}