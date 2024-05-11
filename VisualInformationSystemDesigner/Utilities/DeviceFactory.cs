using System.Windows.Media.Imaging;
using System.Windows.Media;
using VisualInformationSystemDesigner.Model.Device;
using VisualInformationSystemDesigner.Model.Device.Client;
using VisualInformationSystemDesigner.Model.Device.Database;
using VisualInformationSystemDesigner.Model.Device.Server;

namespace VisualInformationSystemDesigner.Utilities
{
    public static class DeviceFactory
    {
        public static DeviceModel CreateDevice(DeviceType deviceType)
        {
            if (deviceType == DeviceType.Database)
            {
                return new DatabaseModel
                {
                    Image = LoadImage("database-icon.png")
                };
            }
            else if (deviceType == DeviceType.Server)
            {
                return new ServerModel
                {
                    Image = LoadImage("server-icon.png")
                };
            }
            else if (deviceType == DeviceType.Client)
            {
                return new ClientModel
                {
                    Image = LoadImage("client-icon.png")
                };
            }

            throw new ArgumentException("Invalid device type.");
        }

        /// <summary>
        /// Получить изображение из ресурсов
        /// </summary>
        /// <param name="imageName">Название изображения из ресурсов</param>
        /// <returns></returns>
        private static ImageSource LoadImage(string imageName)
        {
            return new BitmapImage(new Uri($"pack://application:,,,/Resources/{imageName}"));
        }
    }
}