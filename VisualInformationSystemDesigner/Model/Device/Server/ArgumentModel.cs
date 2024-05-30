namespace VisualInformationSystemDesigner.Model.Device.Server
{
    public class ArgumentModel
    {
        public string Name { get; set; } // Название
        //public string Type { get; set; } // Тип переменной
        public DataType DataType { get; set; }
        public string Value { get; set; } // Значение

        public ArgumentModel() { }
	}
}