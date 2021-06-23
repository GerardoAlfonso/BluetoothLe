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
    public struct KnownDescriptor
    {
        public string Name { get; }
        public Guid Id { get; }

        public KnownDescriptor(string name, Guid id)
        {
            Name = name;
            Id = id;
        }
    }
}