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

        private DatabaseTablesViewModel _databaseTablesVM;

        public ICommand ShowFieldsWindowCommand { get; }

        public TableViewModel(ref TableModel table, DatabaseTablesViewModel databaseTablesVM)
        {
            Table = table;
            _databaseTablesVM = databaseTablesVM;

            ShowFieldsWindowCommand = new RelayCommand(ShowFieldsWindow);
        }

        /// <summary>
        /// Удаление таблицы из списка
        /// </summary>
        public void DeleteTable()
        {
            _databaseTablesVM.DeleteTableVM(Table, this);
        }

        /// <summary>
        /// Отображение окна с данными из таблицы
        /// </summary>
        /// <param name="parameter"></param>
        public void ShowFieldsWindow(object parameter)
        {
            var fieldsViewModel = new FieldsViewModel(ref _table, this);
            var fieldsView = new FieldsView();
			fieldsView.DataContext = fieldsViewModel;
			fieldsView.Show();
        }
    }
}