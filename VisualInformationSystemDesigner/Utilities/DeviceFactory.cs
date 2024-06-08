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
                return new DatabaseModel();
            }
            else if (deviceType == DeviceType.Server)
            {
                return new ServerModel();
            }
            else if (deviceType == DeviceType.Client)
            {
                return new ClientModel();
            }

            throw new ArgumentException("Invalid device type.");
        }
    }
}