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

        public ICommand ShowFieldsWindowCommand { get; }

        public TableViewModel(ref TableModel table)
        {
            Table = table;

            ShowFieldsWindowCommand = new RelayCommand(ShowFieldsWindow);
        }

        /// <summary>
        /// Отображение окна с данными из таблицы
        /// </summary>
        /// <param name="parameter"></param>
        public void ShowFieldsWindow(object parameter)
        {
            var tableFieldsViewModel = new TableFieldsViewModel(ref _table);
            var tableFieldsView = new TableFieldsView();
            tableFieldsView.DataContext = tableFieldsViewModel;
            tableFieldsView.Show();
        }
    }
}