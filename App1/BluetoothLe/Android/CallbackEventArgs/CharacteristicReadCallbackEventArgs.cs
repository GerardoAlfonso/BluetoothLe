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
using Android.Bluetooth;


namespace App1.BluetoothLe.Android.CallbackEventArgs
{
    public class CharacteristicReadCallbackEventArgs
    {
        public BluetoothGattCharacteristic Characteristic { get; }

        public CharacteristicReadCallbackEventArgs(BluetoothGattCharacteristic characteristic)
        {
            Characteristic = characteristic;
        }
    }
}