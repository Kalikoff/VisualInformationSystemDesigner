namespace VisualInformationSystemDesigner.Model.Device.Server
{
    public class ArgumentModel
    {
        public string Name { get; set; } // Название
        public DataType DataType { get; set; } // Тип переменной
        public string Value { get; set; } // Значение

        public ArgumentModel() { }
	}
}