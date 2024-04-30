using MvvmHelpers;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model.Device;
using VisualInformationSystemDesigner.Model.Device.Database;
using VisualInformationSystemDesigner.Utilities;
using VisualInformationSystemDesigner.View;

namespace VisualInformationSystemDesigner.ViewModel
{
    public class DatabaseTablesViewModel : BaseViewModel
    {
        private DatabaseModel _database;
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

        public ICommand AddTableCommand { get; }
        public ICommand ShowColumnsListWindowCommand { get; }



        public DatabaseTablesViewModel(ref DeviceModel device)
        {
            //TabSelectionChangedCommand = new RelayCommand(TabSelectionChanged);

            //ConsoleViewModel = new ConsoleViewModel();

            Database = (DatabaseModel)device;

            AddTableCommand = new RelayCommand(AddTable);
            ShowColumnsListWindowCommand = new RelayCommand(ShowColumnsListWindow);

            //var tablesListViewModel = new TablesListViewModel(ref _database);
            //var tablesListView = new TablesListView();
            //tablesListView.DataContext = tablesListViewModel;

            //_currentPage.Content = tablesListView;
        }



        private void AddTable(object parameter)
        {
            var dialogAddDeviceViewModel = new AddItemDialogViewModel();
            var dialogAddDeviceView = new AddItemDialogView();
            dialogAddDeviceView.DataContext = dialogAddDeviceViewModel;

            if (dialogAddDeviceView.ShowDialog() == true)
            {
                var table = new TableModel { Name = dialogAddDeviceViewModel.ItemName };
                Database.Tables.Add(table);
            }
        }



        public void ShowColumnsListWindow(object obj)
        {
            //if (Device.DeviceType == DeviceType.Database)
            //{
            //    var databaseInfoViewModel = new DatabaseInfoViewModel(ref _device);
            //    var databaseInfoView = new DatabaseInfoView();
            //    databaseInfoView.DataContext = databaseInfoViewModel;
            //    databaseInfoView.Show();
            //}
        }
    }
}