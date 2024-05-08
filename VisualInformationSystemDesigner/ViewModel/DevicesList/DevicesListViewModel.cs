using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model.Device;
using VisualInformationSystemDesigner.Utilities;
using VisualInformationSystemDesigner.View.Dialogs;
using VisualInformationSystemDesigner.ViewModel.Device;
using VisualInformationSystemDesigner.ViewModel.Dialogs;

namespace VisualInformationSystemDesigner.ViewModel.DevicesList
{
    public class DevicesListViewModel : BaseViewModel
    {
        public string ItemTypeName { get; set; }

        public DeviceType DeviceType { get; set; }

        private ObservableCollection<DeviceViewModel> _devices;
        public ObservableCollection<DeviceViewModel> Devices
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

        public ICommand AddDeviceCommand { get; }

        public DevicesListViewModel(string itemTypeName, DeviceType deviceType)
        {
            _devices = new ObservableCollection<DeviceViewModel>();

            AddDeviceCommand = new RelayCommand(AddDevice);

            ItemTypeName = itemTypeName;
            DeviceType = deviceType;

            // Тестовый код
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


        private void AddDevice(object parameter)
        {
            var addItemDialogViewModel = new AddItemDialogViewModel();
            var addItemDialogView = new AddItemDialogView();
            addItemDialogView.DataContext = addItemDialogViewModel;

            if (addItemDialogView.ShowDialog() == true)
            {
                var device = new DeviceViewModel(addItemDialogViewModel.ItemName, DeviceType);
                Devices.Add(device);
            }
        }
    }
}