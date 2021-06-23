using App1.BluetoothLe.Abstractions.Contracts;

namespace App1.BluetoothLe.Abstractions.EventArgs
{
    public class DeviceBondStateChangedEventArgs : System.EventArgs
    {
        public IDevice Device { get; set; }
        public DeviceBondState State { get; set; }
    }
}