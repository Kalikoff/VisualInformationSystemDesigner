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

        private DatabaseModel _database; // Ссылка на базу данных

        public ICommand ShowFieldsWindowCommand { get; }

        public TableViewModel(ref TableModel table, ref DatabaseModel database)
        {
            Table = table;
            _database = database;

            ShowFieldsWindowCommand = new RelayCommand(ShowFieldsWindow);
        }

        /// <summary>
        /// Отображение окна с данными из таблицы
        /// </summary>
        /// <param name="parameter"></param>
        public void ShowFieldsWindow(object parameter)
        {
            var fieldsViewModel = new FieldsViewModel(ref _table, ref _database);
            var fieldsView = new FieldsView();
			fieldsView.DataContext = fieldsViewModel;
			fieldsView.Show();
        }
    }
}