using System.Collections.ObjectModel;

namespace VisualInformationSystemDesigner.Model.Device.Database
{
    public class ColumnModel
    {
        public string Name { get; set; } // Название
        public ObservableCollection<object> Data { get; set; } // Данные
    }
}