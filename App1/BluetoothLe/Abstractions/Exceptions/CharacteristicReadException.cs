﻿using Android.App;
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
    public class CharacteristicReadException : Exception
    {
        public CharacteristicReadException(string message) : base(message)
        {
        }
    }
}