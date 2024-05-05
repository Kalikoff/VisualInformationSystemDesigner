using MvvmHelpers;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model.Device.Database;
using VisualInformationSystemDesigner.Utilities;
using VisualInformationSystemDesigner.View;

namespace VisualInformationSystemDesigner.ViewModel
{
    public class TableViewModel : BaseViewModel
    {
        private TableModel _table;
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

        public ICommand ShowColumnsListWindowCommand { get; }



        public TableViewModel(TableModel table)
        {
            Table = table;

            ShowColumnsListWindowCommand = new RelayCommand(ShowColumnsListWindow);
        }



        public void ShowColumnsListWindow(object obj)
        {
            var databaseColumnsViewModel = new DatabaseColumnsViewModel(_table);
            var databaseColumnsView = new DatabaseColumnsView();
            databaseColumnsView.DataContext = databaseColumnsViewModel;
            databaseColumnsView.Show();
        }
    }
}
