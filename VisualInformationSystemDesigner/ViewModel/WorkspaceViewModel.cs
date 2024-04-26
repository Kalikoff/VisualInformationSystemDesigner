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
            DevicesListViewModel databases = new DevicesListViewModel("БАЗЫ ДАННЫХ", DeviceType.Database);
            DevicesListViewModel servers = new DevicesListViewModel("СЕРВЕРА", DeviceType.Server);
            DevicesListViewModel clients = new DevicesListViewModel("КЛИЕНТЫ", DeviceType.Client);

            DevicesList.Add(databases);
            DevicesList.Add(servers);
            DevicesList.Add(clients);
        }
    }
}