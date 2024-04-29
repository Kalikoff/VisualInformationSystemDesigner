namespace VisualInformationSystemDesigner.Model.Device.Database
{
    public class RelationModel
    {
        public TableModel RelatedTable { get; set; } // Связанная таблица
        public string ForeignKey { get; set; } // Внешний ключ
    }
}