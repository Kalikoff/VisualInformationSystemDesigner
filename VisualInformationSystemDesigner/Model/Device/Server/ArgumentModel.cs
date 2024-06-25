namespace VisualInformationSystemDesigner.Model.Device.Server
{
    public class ArgumentModel
    {
        private string _name = string.Empty;
        public string Name { get { return _name; } set { _name = value; } } // Название
        public string DataType { get; set; } // Тип переменной
        public string Value { get; set; } // Значение

        public ArgumentModel() { }
    }
}