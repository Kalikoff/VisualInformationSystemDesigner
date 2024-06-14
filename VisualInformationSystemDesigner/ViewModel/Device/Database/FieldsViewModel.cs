using Microsoft.VisualBasic.FileIO;
using MvvmHelpers;
using System.Windows;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model.Device.Database;
using VisualInformationSystemDesigner.Utilities;
using VisualInformationSystemDesigner.View.Dialogs;
using VisualInformationSystemDesigner.ViewModel.Dialogs;

namespace VisualInformationSystemDesigner.ViewModel.Device.Database
{
    public class FieldsViewModel : BaseViewModel
    {
        private TableModel _table; // Ссылка на таблицу
        public TableModel Table
        {
            get => _table;
            set
            {
                if (_table != value)
                {
                    _table = value;
                    OnPropertyChanged(nameof(Table));
                }
            }
        }

        private DatabaseModel _database;

        public ICommand DeleteTableCommand { get; }
        public ICommand AddFieldCommand { get; }
        public ICommand DeleteFieldCommand { get; }

        public FieldsViewModel(ref TableModel table, ref DatabaseModel database)
        {
            Table = table;
            _database = database;

            DeleteTableCommand = new RelayCommand<Window>(DeleteTable);
            AddFieldCommand = new RelayCommand(AddField);
            DeleteFieldCommand = new RelayCommand(DeleteField);
        }

        private void DeleteTable(Window window)
        {
            //DeviceListLocator.Instance.Databases.Remove(Database);
            //var databaseVM = DeviceListLocator.Instance.DatabasesVM.First(d => d.Device == Database);
            //DeviceListLocator.Instance.DatabasesVM.Remove(databaseVM);


            //_database.Tables.Remove(Table);
        }

        private void AddField(object parameter)
        {
            var addFieldDialogViewModel = new AddFieldDialogViewModel();
            var addFieldDialogView = new AddFieldDialogView();
            addFieldDialogView.DataContext = addFieldDialogViewModel;

            if (addFieldDialogView.ShowDialog() == true)
            {
                Table.Fields.Add(new FieldModel { Name = addFieldDialogViewModel.ItemName, DataType = addFieldDialogViewModel.ItemDataType });
            }
        }

        private void DeleteField(object parameter)
        {
            if (parameter is FieldModel field)
            {
                Table.Fields.Remove(field);
            }
        }
    }
}