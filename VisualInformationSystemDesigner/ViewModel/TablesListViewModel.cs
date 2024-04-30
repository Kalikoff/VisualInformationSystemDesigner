using MvvmHelpers;
using System.Windows.Controls;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model.Device.Database;
using VisualInformationSystemDesigner.Utilities;
using VisualInformationSystemDesigner.View;

namespace VisualInformationSystemDesigner.ViewModel
{
    public class TablesListViewModel : BaseViewModel
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



        public TablesListViewModel(ref DatabaseModel databaseModel, ref Page currentPage)
        {
            Database = databaseModel;

            AddTableCommand = new RelayCommand(AddTable);
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
    }
}