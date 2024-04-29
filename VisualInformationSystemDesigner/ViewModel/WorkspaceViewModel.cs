using MvvmHelpers;
using VisualInformationSystemDesigner.Model.Device;

namespace VisualInformationSystemDesigner.ViewModel
{
    public class WorkspaceViewModel : BaseViewModel
    {
        private List<DevicesListViewModel> _devicesList = new();
        public List<DevicesListViewModel> DevicesList
        {
            get => _devicesList;
            set
            {
                if (_devicesList != value)
                {
                    _devicesList = value;
                    OnPropertyChanged(nameof(DevicesList));
                }
            }
        }

        public WorkspaceViewModel()
        {
            var databases = new DevicesListViewModel("БАЗЫ ДАННЫХ", DeviceType.Database);
            var servers = new DevicesListViewModel("СЕРВЕРА", DeviceType.Server);
            var clients = new DevicesListViewModel("КЛИЕНТЫ", DeviceType.Client);

            DevicesList.Add(databases);
            DevicesList.Add(servers);
            DevicesList.Add(clients);
        }
    }
}