using System.Collections.ObjectModel;
using VisualInformationSystemDesigner.Model.Device;
using VisualInformationSystemDesigner.ViewModel.Device;

namespace VisualInformationSystemDesigner.Utilities
{
    public class DeviceListLocator
    {
        private static DeviceListLocator _instance;
        public static DeviceListLocator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DeviceListLocator();
                }

                return _instance;
            }
        }

        public ObservableCollection<DeviceModel> Databases { get; set; }
        public ObservableCollection<DeviceViewModel> DatabasesVM { get; set; }

        public ObservableCollection<DeviceModel> Servers { get; set; }
        public ObservableCollection<DeviceViewModel> ServersVM { get; set; }

        public ObservableCollection<DeviceModel> Clients { get; set; }
        public ObservableCollection<DeviceViewModel> ClientsVM { get; set; }

        private DeviceListLocator() { }
    }
}