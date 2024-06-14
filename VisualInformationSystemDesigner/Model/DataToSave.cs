using Newtonsoft.Json;
using System.Collections.ObjectModel;
using VisualInformationSystemDesigner.Model.Device;
using VisualInformationSystemDesigner.Utilities;

namespace VisualInformationSystemDesigner.Model
{
    [JsonConverter(typeof(DeviceModelConverter))]
    public class DataToSave
    {
        public ObservableCollection<DeviceModel> Databases { get; set; }
        public ObservableCollection<DeviceModel> Servers { get; set; }
        public ObservableCollection<DeviceModel> Clients { get; set; }
    }
}