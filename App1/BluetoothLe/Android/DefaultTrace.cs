using System;
using App1.BluetoothLe.Abstractions;


namespace App1.BluetoothLe.Android
{
    static class DefaultTrace
    {
        static DefaultTrace()
        {
            Trace.TraceImplementation = Console.WriteLine;
        }
    }
}