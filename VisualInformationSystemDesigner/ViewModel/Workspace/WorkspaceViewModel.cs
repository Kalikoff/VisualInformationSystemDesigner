using MvvmHelpers;
using VisualInformationSystemDesigner.Model.Device;
using VisualInformationSystemDesigner.ViewModel.DevicesList;

namespace VisualInformationSystemDesigner.ViewModel.Workspace
{
    public class WorkspaceViewModel : BaseViewModel
    {
        private List<DevicesListViewModel> _devicesList = new(); // Список категорий устройств
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


        private List<DeviceModel> _databases = new(); // Список баз данных
        public List<DeviceModel> Databases
        {
            get => _databases;
            set
            {
                if (_databases != value)
                {
                    _databases = value;
                    OnPropertyChanged(nameof(Databases));
                }
            }
        }


        private List<DeviceModel> _servers = new(); // Список серверов
        public List<DeviceModel> Servers
        {
            get => _servers;
            set
            {
                if (_servers != value)
                {
                    _servers = value;
                    OnPropertyChanged(nameof(Servers));
                }
            }
        }


        private List<DeviceModel> _clients = new(); // Список клиентов
        public List<DeviceModel> Clients
        {
            get => _clients;
            set
            {
                if (_clients != value)
                {
                    _clients = value;
                    OnPropertyChanged(nameof(Clients));
                }
            }
        }


        public WorkspaceViewModel()
        {
            var databases = new DevicesListViewModel("БАЗЫ ДАННЫХ", ref _databases, DeviceType.Database);
            var servers = new DevicesListViewModel("СЕРВЕРА", ref _servers, DeviceType.Server);
            var clients = new DevicesListViewModel("КЛИЕНТЫ", ref _clients, DeviceType.Client);

            DevicesList.Add(databases);
            DevicesList.Add(servers);
            DevicesList.Add(clients);
        }
    }
}