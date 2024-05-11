using MvvmHelpers;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model.Device.Database;
using VisualInformationSystemDesigner.Utilities;
using VisualInformationSystemDesigner.View.Device.Database;

namespace VisualInformationSystemDesigner.ViewModel.Device.Database
{
    public class TableViewModel : BaseViewModel
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

        public ICommand ShowColumnsListWindowCommand { get; }

        public TableViewModel(ref TableModel table)
        {
            Table = table;

            ShowColumnsListWindowCommand = new RelayCommand(ShowColumnsListWindow);
        }

        /// <summary>
        /// Отображение окна с данными из таблицы
        /// </summary>
        /// <param name="parameter"></param>
        public void ShowColumnsListWindow(object parameter)
        {
            var databaseColumnsViewModel = new DatabaseColumnsViewModel(ref _table);
            var databaseColumnsView = new DatabaseColumnsView();
            databaseColumnsView.DataContext = databaseColumnsViewModel;
            databaseColumnsView.Show();
        }
    }
}
