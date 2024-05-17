using System.Collections.ObjectModel;

namespace VisualInformationSystemDesigner.Model.Device.Database
{
    public class FieldModel
    {
        public string Name { get; set; } // Название

        public ObservableCollection<object> Data { get; set; } // Данные

        public FieldModel()
        {
            Data = new ObservableCollection<object>();
        }
	}
}