using System.Collections.ObjectModel;

namespace VisualInformationSystemDesigner.Model.Device.Database
{
    public class TableModel
    {
        public string Name { get; set; } // Название
        public ObservableCollection<ColumnModel> Columns { get; set; } = new(); // Столбцы
        public ObservableCollection<RelationModel>? Relations { get; set; } = new(); // Связи с другими таблицами
    }
}