﻿using MvvmHelpers;
using System.Collections.ObjectModel;
using VisualInformationSystemDesigner.Model.Device;
using VisualInformationSystemDesigner.Model.Device.Database;
using VisualInformationSystemDesigner.Model.Device.Server;
using VisualInformationSystemDesigner.Utilities;
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

        public WorkspaceViewModel()
        {
            Test();

            var databases = new DevicesListViewModel("БАЗЫ ДАННЫХ", ref _databases, DeviceType.Database);
            var servers = new DevicesListViewModel("СЕРВЕРА", ref _servers, DeviceType.Server);
            var clients = new DevicesListViewModel("КЛИЕНТЫ", ref _clients, DeviceType.Client);

            DevicesList.Add(databases);
            DevicesList.Add(servers);
            DevicesList.Add(clients);

            DeviceListLocator.Instance.Databases = _databases;
            DeviceListLocator.Instance.Servers = _servers;
            DeviceListLocator.Instance.Clients = _clients;
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
                                Data = [1,2,3]
                            },
                            new()
                            {
                                Name = "Name",
                                Data = ["Masha", "Misha", "Alex"]
                            },
                            new()
                            {
                                Name = "Role",
                                Data = ["Admin", "Client", "Client"]
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
                                Data = [1,2]
                            },
                            new()
                            {
                                Name = "Work",
                                Data = ["Admin", "Programmer"]
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