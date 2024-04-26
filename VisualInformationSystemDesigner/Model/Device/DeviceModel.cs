using System.Windows.Media;

namespace VisualInformationSystemDesigner.Model.Device
{
    public class DeviceModel
    {
        public string Name { get; set; }
        public ImageSource Image { get; set; }
        public DeviceType DeviceType { get; set; }
    }
}