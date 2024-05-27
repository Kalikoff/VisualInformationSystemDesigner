namespace VisualInformationSystemDesigner.Model.Device
{
    public class VariableType
    {
        public static Dictionary<DataType, string> dataTypeDictionary = new Dictionary<DataType, string>();

        static VariableType()
        {
            dataTypeDictionary[DataType.Int] = "int";
            dataTypeDictionary[DataType.Double] = "double";
            dataTypeDictionary[DataType.String] = "string";
        }
    }
}