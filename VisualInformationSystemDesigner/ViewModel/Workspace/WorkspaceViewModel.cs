﻿using MvvmHelpers;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model;
using VisualInformationSystemDesigner.Model.Device;
using VisualInformationSystemDesigner.Model.Device.Database;
using VisualInformationSystemDesigner.Model.Device.Server;
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

        public ICommand SaveProjectCommand { get; }
        public ICommand UploadProjectCommand { get; }

        public WorkspaceViewModel()
        {
            DeviceListLocator.Instance.Databases = _databases;
            DeviceListLocator.Instance.DatabasesVM = _databasesVM;
            DeviceListLocator.Instance.Servers = _servers;
            DeviceListLocator.Instance.ServersVM = _serversVM;
            DeviceListLocator.Instance.Clients = _clients;
            DeviceListLocator.Instance.ClientsVM = _clientsVM;

            Test();

            var databases = new DevicesListViewModel("БАЗЫ ДАННЫХ", ref _databases, ref _databasesVM, DeviceType.Database);
            var servers = new DevicesListViewModel("СЕРВЕРА", ref _servers, ref _serversVM, DeviceType.Server);
            var clients = new DevicesListViewModel("КЛИЕНТЫ", ref _clients, ref _clientsVM, DeviceType.Client);

            DevicesList.Add(databases);
            DevicesList.Add(servers);
            DevicesList.Add(clients);

            SaveProjectCommand = new RelayCommand(SaveProject);
            UploadProjectCommand = new RelayCommand(UploadProject);
        }

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

        public void UploadProject(object parameter)
        {
            string loadedJson = File.ReadAllText("project.json");
            var loadedData = JsonConvert.DeserializeObject<DataToSave>(loadedJson);

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

                OnPropertyChanged(nameof(Databases));
                OnPropertyChanged(nameof(DatabasesVM));
            }

            foreach (var server in loadedData.Servers)
            {
                _servers.Add(server);
                var refServer = _servers[^1];
                _serversVM.Add(new DeviceViewModel(ref refServer));

                OnPropertyChanged(nameof(Servers));
                OnPropertyChanged(nameof(ServersVM));
            }

            foreach (var client in loadedData.Clients)
            {
                _clients.Add(client);
                var refClient = _clients[^1];
                _clientsVM.Add(new DeviceViewModel(ref refClient));

                OnPropertyChanged(nameof(Clients));
                OnPropertyChanged(nameof(ClientsVM));
            }
        }

        private void Test()
        {
            Databases.Add(new DatabaseModel
            {
                DeviceType = DeviceType.Database,
                Name = "DB1",
                Tables = new ObservableCollection<TableModel>
                {
                    new TableModel
                    {
                        Name = "t1",
                        Fields =
                        [
                            new()
                            {
                                Name = "Id",
                                Data = ["1","2","3"],
                                DataType = "Int"
                            },
                            new()
                            {
                                Name = "Name",
                                Data = ["Masha", "Misha", "Alex"],
                                DataType = "String"
                            },
                            new()
                            {
                                Name = "Role",
                                Data = ["Admin", "Client", "Client"],
                                DataType = "String"
                            }
                        ]
                    },
                    new TableModel
                    {
                        Name = "t2",
                        Fields =
                        [
                            new()
                            {
                                Name = "Id",
                                Data = ["1","2"],
                                DataType = "Int"
                            },
                            new()
                            {
                                Name = "Work",
                                Data = ["Admin", "Programmer"],
                                DataType = "String"
                            }
                        ]
                    }
                }
            });

            Servers.Add(new ServerModel
            {
                DeviceType = DeviceType.Server,
                Name = "S1"
            });
        }
    }
}