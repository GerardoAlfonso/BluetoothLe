using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.Content.PM;
using App1.BluetoothLe.Abstractions;
using App1.BluetoothLe.Abstractions.Contracts;
using App1.BluetoothLe.Android.BroadcastReceivers;
using App1.BluetoothLe.Abstractions.Extensions;
using Adapter = App1.BluetoothLe.Android.Adapter;
using IAdapter = App1.BluetoothLe.Abstractions.Contracts.IAdapter;
using App1.BluetoothLe.Android.Extensions;


namespace App1.BluetoothLe.Android
{
    internal class BleImplementation : BleImplementationBase
    {
        private BluetoothManager _bluetoothManager;

        protected override void InitializeNative()
        {
            var ctx = Application.Context;
            if (!ctx.PackageManager.HasSystemFeature(PackageManager.FeatureBluetoothLe))
                return;

            var statusChangeReceiver = new BluetoothStatusBroadcastReceiver(UpdateState);
            ctx.RegisterReceiver(statusChangeReceiver, new IntentFilter(BluetoothAdapter.ActionStateChanged));

            _bluetoothManager = (BluetoothManager)ctx.GetSystemService(Context.BluetoothService);
        }

        protected override BluetoothState GetInitialStateNative()
        {
            if (_bluetoothManager == null)
                return BluetoothState.Unavailable;

            return _bluetoothManager.Adapter.State.ToBluetoothState();
        }

        protected override IAdapter CreateNativeAdapter()
        {
            return new Adapter(_bluetoothManager);
        }

        private void UpdateState(BluetoothState state)
        {
            State = state;
        }
    }
}