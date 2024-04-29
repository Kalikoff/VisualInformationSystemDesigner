using MvvmHelpers;
using System.Windows;
using System.Windows.Input;
using VisualInformationSystemDesigner.Utilities;

namespace VisualInformationSystemDesigner.ViewModel
{
    public class DialogAddDeviceViewModel : BaseViewModel
    {
        private string _deviceName;
        public string DeviceName
        {
            get => _deviceName;
            set
            {
                if (_deviceName != value)
                {
                    _deviceName = value;
                    OnPropertyChanged(nameof(DeviceName));
                }
            }
        }

        public ICommand AddDeviceCommand { get; }

        public ICommand CancelCommand { get; }

        public DialogAddDeviceViewModel()
        {
            AddDeviceCommand = new RelayCommand(AddDevice);
            CancelCommand = new RelayCommand(Cancel);
        }

        public void AddDevice(object parameter)
        {
            var window = parameter as Window;

            if (window != null)
            {
                window.DialogResult = true;
            }
        }

        private void Cancel(object parameter)
        {
            var window = parameter as Window;

            if (window != null)
            {
                window.DialogResult = false;
            }
        }
    }
}