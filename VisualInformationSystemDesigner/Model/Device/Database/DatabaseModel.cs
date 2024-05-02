using System.Collections.ObjectModel;
using VisualInformationSystemDesigner.ViewModel;

namespace VisualInformationSystemDesigner.Model.Device.Database
{
    public class DatabaseModel : DeviceModel
    {
        //public ObservableCollection<TableModel> Tables { get; set; } = new(); // Таблицы
        public ObservableCollection<TableViewModel> Tables { get; set; } = new(); // Таблицы
        
    }
}