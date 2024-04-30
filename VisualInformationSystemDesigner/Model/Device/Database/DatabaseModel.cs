using System.Collections.ObjectModel;

namespace VisualInformationSystemDesigner.Model.Device.Database
{
    public class DatabaseModel : DeviceModel
    {
        public ObservableCollection<TableModel> Tables { get; set; } = new(); // Таблицы
    }
}