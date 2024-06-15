using MvvmHelpers;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model;
using VisualInformationSystemDesigner.Model.Device;
using VisualInformationSystemDesigner.Utilities;
using VisualInformationSystemDesigner.ViewModel.Device;
using VisualInformationSystemDesigner.ViewModel.DevicesList;

namespace VisualInformationSystemDesigner.ViewModel.Workspace
{
    public class WorkspaceViewModel : BaseViewModel
    {
        private ObservableCollection<DevicesListViewModel> _devicesList = new(); // Список категорий устройств
        public ObservableCollection<DevicesListViewModel> DevicesList
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


        private ObservableCollection<DeviceModel> _databases = new(); // Список баз данных
        public ObservableCollection<DeviceModel> Databases
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

        private ObservableCollection<DeviceViewModel> _databasesVM = new(); // Список моделей представления Баз данных
        public ObservableCollection<DeviceViewModel> DatabasesVM
        {
            get => _databasesVM;
            set
            {
                if (_databasesVM != value)
                {
                    _databasesVM = value;
                    OnPropertyChanged(nameof(DatabasesVM));
                }
            }
        }


        private ObservableCollection<DeviceModel> _servers = new(); // Список серверов
        public ObservableCollection<DeviceModel> Servers
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

        private ObservableCollection<DeviceViewModel> _serversVM = new(); // Список моделей представления Серверов
        public ObservableCollection<DeviceViewModel> ServersVM
        {
            get => _serversVM;
            set
            {
                if (_serversVM != value)
                {
                    _serversVM = value;
                    OnPropertyChanged(nameof(ServersVM));
                }
            }
        }


        private ObservableCollection<DeviceModel> _clients = new(); // Список клиентов
        public ObservableCollection<DeviceModel> Clients
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

        private ObservableCollection<DeviceViewModel> _clientsVM = new(); // Список моделей представления Клиентов
        public ObservableCollection<DeviceViewModel> ClientsVM
        {
            get => _clientsVM;
            set
            {
                if (_clientsVM != value)
                {
                    _clientsVM = value;
                    OnPropertyChanged(nameof(ClientsVM));
                }
            }
        }

        public ICommand SaveProjectCommand { get; } // Команда сохранения проекта в файл
        public ICommand UploadProjectCommand { get; } // Команда загрузка проекта из файла

        public WorkspaceViewModel()
        {
            DeviceListLocator.Instance.Databases = _databases;
            DeviceListLocator.Instance.DatabasesVM = _databasesVM;
            DeviceListLocator.Instance.Servers = _servers;
            DeviceListLocator.Instance.ServersVM = _serversVM;
            DeviceListLocator.Instance.Clients = _clients;
            DeviceListLocator.Instance.ClientsVM = _clientsVM;

            var databases = new DevicesListViewModel("БАЗЫ ДАННЫХ", ref _databases, ref _databasesVM, DeviceType.Database);
            var servers = new DevicesListViewModel("СЕРВЕРА", ref _servers, ref _serversVM, DeviceType.Server);
            var clients = new DevicesListViewModel("КЛИЕНТЫ", ref _clients, ref _clientsVM, DeviceType.Client);

            DevicesList.Add(databases);
            DevicesList.Add(servers);
            DevicesList.Add(clients);

            SaveProjectCommand = new RelayCommand(SaveProject);
            UploadProjectCommand = new RelayCommand(UploadProject);
        }

        /// <summary>
        /// Сохранение проекта в файл
        /// </summary>
        /// <param name="parameter"></param>
        private void SaveProject(object parameter)
        {
            var dataToSave = new DataToSave
            {
                Databases = _databases,
                Servers = _servers,
                Clients = _clients
            };

            string json = JsonConvert.SerializeObject(dataToSave, Formatting.Indented);

            File.WriteAllText("project.json", json);
        }

        /// <summary>
        /// Загрузка проекта из файла
        /// </summary>
        /// <param name="parameter"></param>
        public void UploadProject(object parameter)
        {
            string loadedJson = File.ReadAllText("project.json");
            var loadedData = JsonConvert.DeserializeObject<DataToSave>(loadedJson);

            if (loadedData == null)
            {
                return;
            }

            _databases.Clear();
            _databasesVM.Clear();

            _servers.Clear();
            _serversVM.Clear();

            _clients.Clear();
            _clientsVM.Clear();

            foreach(var database in loadedData.Databases)
            {
                _databases.Add(database);
                var refDatabase = _databases[^1];
                _databasesVM.Add(new DeviceViewModel(ref refDatabase));
            }

            foreach (var server in loadedData.Servers)
            {
                _servers.Add(server);
                var refServer = _servers[^1];
                _serversVM.Add(new DeviceViewModel(ref refServer));
            }

            foreach (var client in loadedData.Clients)
            {
                _clients.Add(client);
                var refClient = _clients[^1];
                _clientsVM.Add(new DeviceViewModel(ref refClient));
            }
        }
    }
}