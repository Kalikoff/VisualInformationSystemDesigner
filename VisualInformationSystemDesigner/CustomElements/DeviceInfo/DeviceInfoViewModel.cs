using MvvmHelpers;
using System.Windows.Input;
using VisualInformationSystemDesigner.CustomElements.Console;
using VisualInformationSystemDesigner.Model;
using VisualInformationSystemDesigner.Utilities;

namespace VisualInformationSystemDesigner.CustomElements
{
    public class DeviceInfoViewModel : BaseViewModel
    {
        private Device _device;
        public Device Device
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

        public DeviceInfoViewModel(ref Device device)
        {
            TabSelectionChangedCommand = new RelayCommand(TabSelectionChanged);

            ConsoleViewModel = new ConsoleViewModel();

            this.Device = device;
        }



        private void TabSelectionChanged(object obj)
        {
            Device.Source = Source;
            ConsoleViewModel.UpdateSource(Device.Source);
        }
    }
}