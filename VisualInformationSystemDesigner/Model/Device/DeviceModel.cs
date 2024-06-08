namespace VisualInformationSystemDesigner.Model.Device
{
    public abstract class DeviceModel
    {
        public string Name { get; set; }
        public DeviceType DeviceType { get; set; }

        public abstract void ShowDeviceInformation(ref DeviceModel device);
    }
}