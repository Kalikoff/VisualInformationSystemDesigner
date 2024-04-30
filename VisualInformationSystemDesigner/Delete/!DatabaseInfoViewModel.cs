using MvvmHelpers;
using System.Windows.Controls;
using VisualInformationSystemDesigner.Model.Device;
using VisualInformationSystemDesigner.Model.Device.Database;
using VisualInformationSystemDesigner.View;

namespace VisualInformationSystemDesigner.ViewModel
{
    public class DatabaseInfoViewModel : BaseViewModel
    {
        private DatabaseModel _database;
        public DatabaseModel Database
        {
            get => _database;
            set
            {
                if (_database != value)
                {
                    _database = value;
                    OnPropertyChanged(nameof(Database));
                }
            }
        }

        private Page _currentPage;
        public Page CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged(nameof(CurrentPage));
                }
            }
        }

        public DatabaseInfoViewModel(ref DeviceModel device)
        {
            //TabSelectionChangedCommand = new RelayCommand(TabSelectionChanged);

            //ConsoleViewModel = new ConsoleViewModel();

            Database = (DatabaseModel)device;

            _currentPage = new Page();

            var tablesListViewModel = new TablesListViewModel(ref _database, ref _currentPage);
            var tablesListView = new TablesListView();
            tablesListView.DataContext = tablesListViewModel;

            _currentPage.Content = tablesListView;
        }
    }
}