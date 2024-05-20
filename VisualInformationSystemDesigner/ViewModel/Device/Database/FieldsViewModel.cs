using MvvmHelpers;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model.Device.Database;
using VisualInformationSystemDesigner.Utilities;

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

        public ICommand Command { get; }
        
        public FieldsViewModel(ref TableModel table)
        {
            Table = table;

            Command = new RelayCommand(MyCommand);
        }

        private void MyCommand(object parameter)
        {

        }
    }
}