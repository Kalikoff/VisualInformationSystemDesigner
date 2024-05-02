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



        public DatabaseTablesViewModel(ref DeviceModel database)
        {
            Database = (DatabaseModel)database;

            AddTableCommand = new RelayCommand(AddTable);
            //ShowColumnsListWindowCommand = new RelayCommand(ShowColumnsListWindow);
        }



        private void AddTable(object parameter)
        {
            var dialogAddDeviceViewModel = new AddItemDialogViewModel();
            var dialogAddDeviceView = new AddItemDialogView();
            dialogAddDeviceView.DataContext = dialogAddDeviceViewModel;

            if (dialogAddDeviceView.ShowDialog() == true)
            {
                Database.Tables.Add(new TableViewModel(new TableModel { Name = dialogAddDeviceViewModel.ItemName }));
                //var table = new TableModel { Name = dialogAddDeviceViewModel.ItemName };
                //Database.Tables.Add(table);
            }
        }



        public void ShowColumnsListWindow(object obj)
        {
            
        }
    }
}