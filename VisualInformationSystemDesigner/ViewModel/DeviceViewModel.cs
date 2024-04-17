using MvvmHelpers;
using System.Windows.Input;
using System.Windows.Media;
using VisualInformationSystemDesigner.Model;
using VisualInformationSystemDesigner.Utilities;
using VisualInformationSystemDesigner.View;

namespace VisualInformationSystemDesigner.ViewModel
{
    public class DeviceViewModel : BaseViewModel
    {
        private DeviceModel _device; // Данные устройства
        private double _left; // Позиция на форме по X
        private double _top; // Позиция на форме по Y
        private bool _powerStatus; // Текущий статус устройства

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
            Device = new DeviceModel();
            Device.Name = name;
            Device.Image = image;

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