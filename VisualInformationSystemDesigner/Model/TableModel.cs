namespace VisualInformationSystemDesigner.Model
{
    public class TableModel
    {
        public string Name { get; set; } // Название
        public List<ColumnModel> Columns { get; set; } // Столбцы
    }
}