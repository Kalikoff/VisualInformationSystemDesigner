﻿namespace VisualInformationSystemDesigner.Model.Device.Database
{
    public class TableModel
    {
        public string Name { get; set; } // Название
        public List<ColumnModel> Columns { get; set; } // Столбцы
        public List<RelationModel> Relations { get; set; } // Связи с другими таблицами
    }
}