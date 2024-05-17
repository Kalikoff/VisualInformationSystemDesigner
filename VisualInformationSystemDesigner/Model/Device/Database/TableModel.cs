using System.Collections.ObjectModel;

namespace VisualInformationSystemDesigner.Model.Device.Database
{
    public class TableModel
    {
        public string Name { get; set; } // Название

        public ObservableCollection<FieldModel> Fields { get; set; } // Поля

        public TableModel()
        {
            Fields = new ObservableCollection<FieldModel>();
        }
	}
}