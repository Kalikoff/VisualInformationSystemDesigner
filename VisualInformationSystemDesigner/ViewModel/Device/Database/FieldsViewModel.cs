using MvvmHelpers;
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

        public ICommand AddFieldCommand { get; }
        public ICommand DeleteFieldCommand { get; }

        public FieldsViewModel(ref TableModel table)
        {
            Table = table;

            AddFieldCommand = new RelayCommand(AddField);
            DeleteFieldCommand = new RelayCommand(DeleteField);
        }

        private void AddField(object parameter)
        {
            var addFieldDialogViewModel = new AddFieldDialogViewModel();
            var addFieldDialogView = new AddFieldDialogView();
            addFieldDialogView.DataContext = addFieldDialogViewModel;

            if (addFieldDialogView.ShowDialog() == true)
            {
                Table.Fields.Add(new FieldModel { Name = addFieldDialogViewModel.ItemName, Type = addFieldDialogViewModel.ItemDataType });
                
            }
        }

        private void DeleteField(object parameter)
        {

        }
    }
}