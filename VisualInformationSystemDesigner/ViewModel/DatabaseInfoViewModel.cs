using MvvmHelpers;
using System.Windows.Controls;
using VisualInformationSystemDesigner.Model.Device;
using VisualInformationSystemDesigner.Model.Device.Database;

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

        public Page CurrentPage { get; set; }

        public string WindowName {
            get
            {
                return "Настройка устройства: \"" + Database.Name + "\"";
            }
        }

        public DatabaseInfoViewModel(ref DeviceModel device)
        {
            //TabSelectionChangedCommand = new RelayCommand(TabSelectionChanged);

            //ConsoleViewModel = new ConsoleViewModel();

            Database = (DatabaseModel)device;
        }
    }
}