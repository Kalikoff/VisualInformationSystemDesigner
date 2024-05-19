using System.Globalization;
using System.Windows.Data;

namespace VisualInformationSystemDesigner.ViewModel.Device.Server
{
    public class ActionToTabIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 0;

            switch (value.ToString())
            {
                case "Добавить":
                    return 0;
                case "Изменить":
                    return 1;
                case "Получить":
                    return 2;
                case "Удалить":
                    return 3;
                default:
                    return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}