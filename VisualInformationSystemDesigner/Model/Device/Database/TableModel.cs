using System.Collections.ObjectModel;

namespace VisualInformationSystemDesigner.Model.Device.Database
{
    public class TableModel
    {
        public string Name { get; set; } // Название
        //public ObservableCollection<ColumnModel> Columns { get; set; } // Столбцы
        public ObservableCollection<string> ColumnsName { get; set; }
        public ObservableCollection<RowModel> Rows { get; set; }
        //public ObservableCollection<RelationModel>? Relations { get; set; } = new(); // Связи с другими таблицами

        public TableModel()
        {
            //Columns = new ObservableCollection<ColumnModel>();
            ColumnsName = new ObservableCollection<string>();
            Rows = new ObservableCollection<RowModel>();
        }
    }
}