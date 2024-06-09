using System.Globalization;
using System.Windows.Data;
using VisualInformationSystemDesigner.Model.Device;

namespace VisualInformationSystemDesigner.Utilities
{
    public class DataTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DataType status)
            {
                switch (status)
                {
                    case DataType.Int:
                        return "Int";
                    case DataType.Double:
                        return "Doule";
                    case DataType.String:
                        return "String";
                    default:
                        return "Неизвестный тип данных!";
                }
            }

            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}