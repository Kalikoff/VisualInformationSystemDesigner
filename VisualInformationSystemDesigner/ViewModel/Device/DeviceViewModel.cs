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

        public DeviceViewModel(ref DeviceModel device)
        {
            _device = device;
            Image = GetDeviceImage();

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

        /// <summary>
        /// Получить изображение из ресурсов
        /// </summary>
        /// <returns>Ссылка на изображение из ресурсов</returns>
        private BitmapImage GetDeviceImage()
        {
            string imageName = "";

            if (_device.DeviceType == DeviceType.Database)
            {
                imageName = "database-icon.png";
            }
            else if (_device.DeviceType == DeviceType.Server)
            {
                imageName = "server-icon.png";
            }
            else if (_device.DeviceType == DeviceType.Client)
            {
                imageName = "client-icon.png";
            }

            return new BitmapImage(new Uri($"pack://application:,,,/Resources/{imageName}"));
        }
    }
}