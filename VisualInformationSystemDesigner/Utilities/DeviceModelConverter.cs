using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using VisualInformationSystemDesigner.Model.Device.Client;
using VisualInformationSystemDesigner.Model.Device.Database;
using VisualInformationSystemDesigner.Model.Device.Server;
using VisualInformationSystemDesigner.Model.Device;
using System.Collections.ObjectModel;
using VisualInformationSystemDesigner.Model;

namespace VisualInformationSystemDesigner.Utilities
{
    public class DeviceModelConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(DataToSave));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            var dataToSave = new DataToSave
            {
                Databases = DeserializeDeviceModels(jo["Databases"]),
                Servers = DeserializeDeviceModels(jo["Servers"]),
                Clients = DeserializeDeviceModels(jo["Clients"])
            };

            return dataToSave;
        }

        private ObservableCollection<DeviceModel> DeserializeDeviceModels(JToken token)
        {
            var items = new ObservableCollection<DeviceModel>();
            foreach (var item in token)
            {
                var deviceType = (DeviceType)item["DeviceType"].Value<int>();
                DeviceModel device = null;

                switch (deviceType)
                {
                    case DeviceType.Database:
                        device = new DatabaseModel();
                        break;
                    case DeviceType.Server:
                        device = new ServerModel();
                        break;
                    case DeviceType.Client:
                        device = new ClientModel();
                        break;
                }

                if (device != null)
                {
                    JsonConvert.PopulateObject(item.ToString(), device);
                    items.Add(device);
                }
            }

            return items;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject jo = new JObject();

            var dataToSave = (DataToSave)value;
            jo["Databases"] = JArray.FromObject(dataToSave.Databases, serializer);
            jo["Servers"] = JArray.FromObject(dataToSave.Servers, serializer);
            jo["Clients"] = JArray.FromObject(dataToSave.Clients, serializer);

            jo.WriteTo(writer);
        }
    }
}
