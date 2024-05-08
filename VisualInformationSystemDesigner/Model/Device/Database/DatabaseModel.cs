using System.Collections.ObjectModel;
using VisualInformationSystemDesigner.ViewModel.Device.Database;

namespace VisualInformationSystemDesigner.Model.Device.Database
{
    public class DatabaseModel : DeviceModel
    {
        //public ObservableCollection<TableModel> Tables { get; set; } = new(); // Таблицы
        public ObservableCollection<TableViewModel> Tables { get; set; } // Таблицы

        public DatabaseModel()
        {
            Tables = new ObservableCollection<TableViewModel>();
        }
    }
}