using MvvmHelpers;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using VisualInformationSystemDesigner.Model.Device;
using VisualInformationSystemDesigner.Utilities;

namespace VisualInformationSystemDesigner.ViewModel.Device
{
    public class DeviceViewModel : BaseViewModel
    {
        private DeviceModel _device; // Ссылка на устройство
        public DeviceModel Device
        {
            get => _device;
            set
            {
                if (_device != value)
                {
                    _device = value;
                    OnPropertyChanged();
                }
            }
        }

        public BitmapImage Image { get; set; }

        public ICommand ShowDeviceInfoWindowCommand { get; }

        public DeviceViewModel(ref DeviceModel device, BitmapImage image)
        {
            _device = device;
            Image = image;

            ShowDeviceInfoWindowCommand = new RelayCommand(ShowDeviceInfoWindow);
        }

        /// <summary>
        /// Отображение окна с информацией об устройстве
        /// </summary>
        /// <param name="parameter"></param>
        public void ShowDeviceInfoWindow(object parameter)
        {
            _device.ShowDeviceInformation(ref _device);
        }
    }
}