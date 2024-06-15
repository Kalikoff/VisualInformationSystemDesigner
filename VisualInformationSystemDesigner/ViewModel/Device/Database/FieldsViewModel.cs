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

        public TableViewModel _tableVM; // Ссылка на представление моделеи таблицы

        public ICommand DeleteTableCommand { get; }
        public ICommand AddFieldCommand { get; }
        public ICommand DeleteFieldCommand { get; }

        public FieldsViewModel(ref TableModel table, TableViewModel tableVM)
        {
            Table = table;
            _tableVM = tableVM;

            DeleteTableCommand = new RelayCommand<Window>(DeleteTable);
            AddFieldCommand = new RelayCommand(AddField);
            DeleteFieldCommand = new RelayCommand(DeleteField);
        }

        /// <summary>
        /// Удаление таблицы
        /// </summary>
        /// <param name="window"></param>
        private void DeleteTable(Window window)
        {
            _tableVM.DeleteTable();
            window.Close();
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