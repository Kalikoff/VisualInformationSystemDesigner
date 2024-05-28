namespace VisualInformationSystemDesigner.Model.Device
{
    public enum DataType
    {
        Int,
        Double,
        String
    }

    public class VariableType
    {
        public static Dictionary<DataType, string> dataTypeDictionary = new Dictionary<DataType, string>
        {
            { DataType.Int, "int" },
            { DataType.Double, "double" },
            { DataType.String, "string" }
        };
    }
}