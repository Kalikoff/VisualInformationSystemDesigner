using MvvmHelpers;
using VisualInformationSystemDesigner.Model;
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

        public DatabaseInfoViewModel()
        {
            //Database = (DatabaseModel)device;
        }
    }
}