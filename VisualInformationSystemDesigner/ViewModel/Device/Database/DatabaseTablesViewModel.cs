using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model.Device;
using VisualInformationSystemDesigner.Model.Device.Database;
using VisualInformationSystemDesigner.Utilities;
using VisualInformationSystemDesigner.View.Dialogs;
using VisualInformationSystemDesigner.ViewModel.Dialogs;

namespace VisualInformationSystemDesigner.ViewModel.Device.Database
{
    public class DatabaseTablesViewModel : BaseViewModel
    {
        private DatabaseModel _database; // Ссылка на базу данных
        public DatabaseModel Database
        {
            get => _database;
            set
            {
                if (_database != value)
                {
                    _database = value;
                    OnPropertyChanged(nameof(Database));
                }
            }
        }

        private ObservableCollection<TableViewModel> _tablesVM = new(); // Список таблиц базы данных
        public ObservableCollection<TableViewModel> TablesVM
        {
            get => _tablesVM;
            set
            {
                if (_tablesVM != value)
                {
                    _tablesVM = value;
                    OnPropertyChanged(nameof(TablesVM));
                }
            }
        }

        public ICommand DeleteDeviceCommand { get; }
        public ICommand AddTableCommand { get; }
        
        public DatabaseTablesViewModel(ref DeviceModel database)
        {
            Database = (DatabaseModel)database;

            // Получение всех таблиц из БД
            for (int i = 0; i < Database.Tables.Count; i++)
            {
                var table = Database.Tables[i];
                TablesVM.Add(new TableViewModel(ref table));
            }

            DeleteDeviceCommand = new RelayCommand<Window>(DeleteDevice);
            AddTableCommand = new RelayCommand(AddTable);
        }

        /// <summary>
        /// Удалить это устройство
        /// </summary>
        /// <param name="window">Экземпляр текущего окна</param>
        private void DeleteDevice(Window window)
        {
            DeviceListLocator.Instance.Databases.Remove(Database);
            var databaseVM = DeviceListLocator.Instance.DatabasesVM.First(d => d.Device == Database);
            DeviceListLocator.Instance.DatabasesVM.Remove(databaseVM);

            window.Close();
        }

        /// <summary>
        /// Создание новой таблицы
        /// </summary>
        /// <param name="parameter"></param>
        private void AddTable(object parameter)
        {
            var dialogAddDeviceViewModel = new AddItemDialogViewModel();
            var dialogAddDeviceView = new AddItemDialogView();
            dialogAddDeviceView.DataContext = dialogAddDeviceViewModel;

            if (dialogAddDeviceView.ShowDialog() == true)
            {
                // Тестовый код
                Database.Tables.Add(new TableModel
                {
                    Name = dialogAddDeviceViewModel.ItemName,
                    Fields =
                    [
                        new()
                        {
                            Name = "Id",
                            Data = ["1","2","3"],
                            Type = DataType.Int
                        },
                        new()
                        {
                            Name = "Name",
                            Data = ["Masha", "Misha", "Alex"],
                            Type = DataType.String
                        },
                        new()
                        {
                            Name = "Role",
                            Data = ["Admin", "Client", "Client"],
                            Type = DataType.String
                        }
                    ]
                });
                ///////////////////////////////////////////////////

                //Database.Tables.Add(new TableModel { Name = dialogAddDeviceViewModel.ItemName }); // Добавление таблицы

                var table = Database.Tables[^1];

                TablesVM.Add(new TableViewModel(ref table));
            }
        }
    }
}