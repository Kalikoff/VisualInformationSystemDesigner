using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using VisualInformationSystemDesigner.Model.Device;
using VisualInformationSystemDesigner.Utilities;
using VisualInformationSystemDesigner.View.Dialogs;
using VisualInformationSystemDesigner.ViewModel.Device;
using VisualInformationSystemDesigner.ViewModel.Dialogs;

namespace VisualInformationSystemDesigner.ViewModel.DevicesList
{
    public class DevicesListViewModel : BaseViewModel
    {
        public string DevicesListName { get; set; } // Название категории списка устройств
        
        private ObservableCollection<DeviceModel> _devices; // Список устройств
        private DeviceType _deviceType { get; set; } // Тип устройств

        private ObservableCollection<DeviceViewModel> _devicesVM; // Список моделей представления устройств
        public ObservableCollection<DeviceViewModel> DevicesVM
        {
            get => _devicesVM;
            set
            {
                if (_devicesVM != value)
                {
                    _devicesVM = value;
                    OnPropertyChanged(nameof(DevicesVM));
                }
            }
        }

        public ICommand AddDeviceCommand { get; }

        public DevicesListViewModel(string devicesListName,
                                    ref ObservableCollection<DeviceModel> devices,
                                    ref ObservableCollection<DeviceViewModel> devicesVM,
                                    DeviceType deviceType)
        {
            DevicesListName = devicesListName;
            _devices = devices;
            _devicesVM = devicesVM;
            _deviceType = deviceType;

            // Отображение всех устройств
            for (int i = 0; i < _devices.Count; i++)
            {
                var device = _devices[i];
                DevicesVM.Add(new DeviceViewModel(ref device, GetDeviceImage()));
            }

            AddDeviceCommand = new RelayCommand(AddDevice);
        }

        /// <summary>
        /// Создание нового устройства
        /// </summary>
        /// <param name="parameter"></param>
        private void AddDevice(object parameter)
        {
            var addItemDialogViewModel = new AddItemDialogViewModel();
            var addItemDialogView = new AddItemDialogView();
            addItemDialogView.DataContext = addItemDialogViewModel;

            if (addItemDialogView.ShowDialog() == true)
            {
                var newDevice = DeviceFactory.CreateDevice(_deviceType);
                newDevice.Name = addItemDialogViewModel.ItemName;
                newDevice.DeviceType = _deviceType;

                _devices.Add(newDevice);
                var device = _devices[^1];

                var deviceVM = new DeviceViewModel(ref device, GetDeviceImage());
                DevicesVM.Add(deviceVM);
            }
        }

        /// <summary>
        /// Получить изображение из ресурсов
        /// </summary>
        /// <returns>Ссылка на изображение из ресурсов</returns>
        private BitmapImage GetDeviceImage()
        {
            string imageName = "";

            if (_deviceType == DeviceType.Database)
            {
                imageName = "database-icon.png";
            }
            else if (_deviceType == DeviceType.Server)
            {
                imageName = "server-icon.png";
            }
            else if (_deviceType == DeviceType.Client)
            {
                imageName = "client-icon.png";
            }
            
            return new BitmapImage(new Uri($"pack://application:,,,/Resources/{imageName}"));
        }
    }
}