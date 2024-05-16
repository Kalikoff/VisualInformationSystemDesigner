namespace VisualInformationSystemDesigner.Model.Device.Server
{
    public class ArgumentModel
    {
        public string Name { get; set; } // Название
        public string Type { get; set; } // Тип переменной
        public object Value { get; set; } // Значение

        public ArgumentModel() { }
    }
}