using MvvmHelpers;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model;
using VisualInformationSystemDesigner.Utilities;

namespace VisualInformationSystemDesigner.ViewModel
{
    public class DeviceInfoViewModel : BaseViewModel
    {
        private DeviceModel _device;
        public DeviceModel Device
        {
            get => _device;
            set
            {
                if (_device != value)
                {
                    _device = value;
                    OnPropertyChanged(nameof(Device));
                }
            }
        }

        public ConsoleViewModel ConsoleViewModel { get; set; }


        public string Source { get; set; }

        public ICommand TabSelectionChangedCommand { get; }

        public DeviceInfoViewModel(ref DeviceModel device)
        {
            TabSelectionChangedCommand = new RelayCommand(TabSelectionChanged);

            ConsoleViewModel = new ConsoleViewModel();

            Device = device;
        }



        private void TabSelectionChanged(object obj)
        {
            Device.Source = Source;
            ConsoleViewModel.UpdateSource(Device.Source);
        }
    }
}