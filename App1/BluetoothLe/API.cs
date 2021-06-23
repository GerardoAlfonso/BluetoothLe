using App1.BluetoothLe.Abstractions.Contracts;
using App1.BluetoothLe.Abstractions.Exceptions;
using App1.BluetoothLe.BLE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace App1.BluetoothLe
{
    class API
    {
        IAdapter adapter;
        IBluetoothLE bluetoothBLE;
        ObservableCollection<IDevice> list;

        public API()
        {
            bluetoothBLE = CrossBluetoothLE.Current;
            adapter = CrossBluetoothLE.Current.Adapter;
            list = new ObservableCollection<IDevice>();
        }


        public async Task<ObservableCollection<IDevice>> ScannModeAsync()
        {
            list.Clear();
            try
            {
                adapter.ScanTimeout = 5000;
                adapter.ScanMode = ScanMode.Balanced;

                adapter.DeviceDiscovered += (obj, a) =>
                {
                    if (!list.Contains(a.Device))
                        list.Add(a.Device);
                };

                //Start Scanning
                await adapter.StartScanningForDevicesAsync();

                var devices = list.ToList();
            }catch (Exception ex)
            {

            }
            return list;
        }

        //Get a list of devices and get device name
        public async Task<IDevice> SelectDeviceAsync(ObservableCollection<IDevice> devices, string name)
        {
            if(name != "" || name != null)
            {
                //await adapter.StopScanningForDevicesAsync();
                foreach (var item in devices)
                {
                    if (item.Name == name)
                    {
                        await ConnectAsync(item);
                        if (item.State == Abstractions.DeviceState.Connected)
                        {
                            return item;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            return null;
        }

        private async Task ConnectAsync(IDevice device)
        {
            try
            {
                await adapter.ConnectToDeviceAsync(device);
            }
            catch (DeviceConnectionException ex)
            {
                //await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        #region services

        public async Task<IReadOnlyList<IService>> GetServices(IDevice device)
        {
            IReadOnlyList<IService> services;
            if (device.State == Abstractions.DeviceState.Connected)
            {
                services = (IReadOnlyList<IService>)await device.GetServicesAsync();
                return services;
            }
            return null;
        }
        public async Task<IService> GetService(IReadOnlyList<IService> services,IDevice device, int position)
        {
            IService service;
            if(position <= services.Count)
            {
                service = await device.GetServiceAsync(services[position].Id);
                return service;
            }
            return null;
        }
        #endregion

        #region characteristics

        public async Task<IReadOnlyList<ICharacteristic>> GetCharacteristics(IService service, IDevice device)
        {
            IReadOnlyList<ICharacteristic> characteristics;
            if (device.State == Abstractions.DeviceState.Connected)
            {
                characteristics = await service.GetCharacteristicsAsync();
                return characteristics;
            }
            return null;
        }
        public async Task<byte[]> GetCharacteristic (IReadOnlyList<ICharacteristic> characteristics,IService service,IDevice device, int position)
        {
            if (device.State == Abstractions.DeviceState.Connected)
            {
                var characteristic = await service.GetCharacteristicAsync(characteristics[position].Id);
                var data = await characteristic.ReadAsync();

                //retry
                if (data == null)
                {
                    data = await characteristic.ReadAsync();
                }
                return data;
            }
            return null;
        }

        #endregion








    }
}