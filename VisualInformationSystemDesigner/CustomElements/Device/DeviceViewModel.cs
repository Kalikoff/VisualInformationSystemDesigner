using MvvmHelpers;
using System.Windows.Input;
using System.Windows.Media;
using VisualInformationSystemDesigner.Model;
using VisualInformationSystemDesigner.Utilities;

namespace VisualInformationSystemDesigner.CustomElements
{
    public class DeviceViewModel : BaseViewModel
    {
        private Device _device; // Данные устройства
        private double _left; // Позиция на форме по X
        private double _top; // Позиция на форме по Y
        private bool _powerStatus; // Текущий статус устройства
       
        public Device Device
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

        public double Left
        {
            get => _left;
            set
            {
                if (_left != value)
                {
                    _left = value;
                    OnPropertyChanged(nameof(Left));
                }
            }
        }

        public double Top
        {
            get => _top;
            set
            {
                if (_top != value)
                {
                    _top = value;
                    OnPropertyChanged(nameof(Top));
                }
            }
        }

        public bool PowerStatus
        {
            get => _powerStatus;
            set
            {
                if (_powerStatus != value)
                {
                    _powerStatus = value;
                }
            }
        }

        public DeviceViewModel(string name, ImageSource image)
        {
            this.Device = new Device();
            this.Device.Name = name;
            this.Device.Image = image;

            ShowDeviceInfoWindowCommand = new RelayCommand(ShowDeviceInfoWindow);
        }

        public ICommand ShowDeviceInfoWindowCommand { get; }

        public void ShowDeviceInfoWindow(object obj)
        {
            var deviceInfoViewModel = new DeviceInfoViewModel(ref _device);
            var deviceInfoView = new DeviceInfoView();
            deviceInfoView.DataContext = deviceInfoViewModel;
            deviceInfoView.Show();
        }
    }
}