using App1.BluetoothLe.Abstractions.Contracts;

namespace App1.BluetoothLe.Abstractions.EventArgs
{
    public class DeviceEventArgs : System.EventArgs
    {
        public IDevice Device;
    }
}