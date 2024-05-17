using VisualInformationSystemDesigner.Model.Device.Database;

namespace VisualInformationSystemDesigner.Model.Device.Server
{
    public class ConditionModel
    {
        public TableModel Table { get; set; } // Таблица из который берётся поле
        public FieldModel Field { get; set; } // Поле
        public string Condition { get; set; } // Условие
        public ArgumentModel Argument { get; set; } // Аргумент

        public ConditionModel() { }
	}
}