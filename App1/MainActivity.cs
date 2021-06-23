using Android;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using App1.BluetoothLe.BLE;
using App1.BluetoothLe.Abstractions;
using App1.BluetoothLe.Abstractions.Contracts;
using App1.BluetoothLe.Abstractions.Exceptions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.BluetoothLe;

namespace App1
{
    [Activity(Label = "VH-75T", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button escanear;
        ListView devicesC;
        ListView devicesD;

        BluetoothLe.Abstractions.Contracts.IAdapter adapter;
        IBluetoothLE bluetoothBLE;
        API ble;

        Android.App.AlertDialog alert;

        public object LayoutWaiting { get; internal set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            
            escanear = FindViewById<Button>(Resource.Id.escanear);
            ble = new API();

            bluetoothBLE = CrossBluetoothLE.Current;
            adapter = CrossBluetoothLE.Current.Adapter;

            this.RequestPermissions(new[]
           {
                Manifest.Permission.Bluetooth,
                Manifest.Permission.BluetoothPrivileged,

                Manifest.Permission.AccessCoarseLocation,
                Manifest.Permission.BluetoothPrivileged

            }, 0);

            escanear.Click += async delegate
            {
                if (bluetoothBLE.State == BluetoothState.On)
                {
                    //Listar dispositivos
                    var list = await ble.ScannModeAsync();
                    //Conectar a un dispositivo por su nombre
                    var deviceConnected = await ble.SelectDeviceAsync(list, "Microsoft Bluetooth Mouse");
                    //Validar si se ha conectado
                    if (deviceConnected.State == DeviceState.Connected)
                    {
                        //listar servicios
                        var services = await ble.GetServices(deviceConnected);

                        #region generic services
                        //seleccionar un unico servicio
                        var service = await ble.GetService(services, deviceConnected, 2);
                        //listar caracteristicas
                        var characteristics = await ble.GetCharacteristics(service, deviceConnected);

                        //seleccionar una caracteristica
                        var hexSerialNumber = await ble.GetCharacteristic(characteristics, service,deviceConnected, 1);
                        string num = Encoding.ASCII.GetString(hexSerialNumber);

                        //Seleccion de otra caracteristica
                        var hexManufacturedName = await ble.GetCharacteristic(characteristics, service, deviceConnected, 0);
                        string manufacturedName = Encoding.ASCII.GetString(hexManufacturedName);
                        #endregion

                        #region battery service

                        var service2 = await ble.GetService(services, deviceConnected, 3);
                        var characteristics2 = await ble.GetCharacteristics(service2, deviceConnected);
                        var hexBattery = await ble.GetCharacteristic(characteristics2, service2, deviceConnected, 0);
                        #endregion

                    }
                }
            };

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}