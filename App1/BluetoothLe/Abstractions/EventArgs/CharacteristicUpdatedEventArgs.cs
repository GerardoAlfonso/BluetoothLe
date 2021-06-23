using App1.BluetoothLe.Abstractions.Contracts;

namespace App1.BluetoothLe.Abstractions.EventArgs
{
    public class CharacteristicUpdatedEventArgs : System.EventArgs
    {
        public ICharacteristic Characteristic { get; set; }

        public CharacteristicUpdatedEventArgs(ICharacteristic characteristic)
        {
            Characteristic = characteristic;
        }
    }
}