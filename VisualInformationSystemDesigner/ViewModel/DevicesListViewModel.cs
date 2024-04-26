using MvvmHelpers;
using VisualInformationSystemDesigner.Model.Device;

namespace VisualInformationSystemDesigner.ViewModel
{
    public class DevicesListViewModel : BaseViewModel
    {
        public string ItemTypeName { get; set; }

        public DeviceType DeviceType { get; set; }


        private List<DeviceViewModel> _devices = new();
        public List<DeviceViewModel> Devices
        {
            get => _devices;
            set
            {
                if (_devices != value)
                {
                    _devices = value;
                    OnPropertyChanged(nameof(Devices));
                }
            }
        }

        public DevicesListViewModel(string itemTypeName, DeviceType deviceType)
        {
            ItemTypeName = itemTypeName;
            DeviceType = deviceType;

            if (DeviceType == DeviceType.Database)
            {
                var database1 = new DeviceViewModel("Название БД 1", DeviceType);
                var database2 = new DeviceViewModel("Название БД 2", DeviceType);

                Devices.Add(database1);
                Devices.Add(database2);
            }
            else if (DeviceType == DeviceType.Server)
            {
                var server1 = new DeviceViewModel("Название Сервера 1", DeviceType);

                Devices.Add(server1);
            }
            else if (DeviceType == DeviceType.Client)
            {
                var client1 = new DeviceViewModel("Название Клиента 1", DeviceType);
                var client2 = new DeviceViewModel("Название Клиента 2", DeviceType);
                var client3 = new DeviceViewModel("Название Клиента 3", DeviceType);

                Devices.Add(client1);
                Devices.Add(client2);
                Devices.Add(client3);
            }
        }
    }
}