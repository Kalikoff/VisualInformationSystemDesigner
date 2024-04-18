using MvvmHelpers;
using VisualInformationSystemDesigner.Model;

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

        public DatabaseInfoViewModel(ref ItemModel device)
        {
            Database = (DatabaseModel)device;
        }
    }
}