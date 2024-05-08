using MvvmHelpers;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model.Device.Database;
using VisualInformationSystemDesigner.Utilities;

namespace VisualInformationSystemDesigner.ViewModel.Device.Database
{
    public class DatabaseColumnsViewModel : BaseViewModel
    {
        private TableModel _table;
        public TableModel Table
        {
            get; set;
        }

        public ICommand Command { get; }

        public DatabaseColumnsViewModel(TableModel table)
        {
            Table = table;

            Command = new RelayCommand(MyCommand);
        }

        private void MyCommand(object obj)
        {

        }
    }
}