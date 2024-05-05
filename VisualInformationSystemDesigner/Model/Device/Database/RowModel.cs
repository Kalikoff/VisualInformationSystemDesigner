using System.Collections.ObjectModel;

namespace VisualInformationSystemDesigner.Model.Device.Database
{
    public class RowModel
    {
        public ObservableCollection<object> Columns { get; set; }

        public RowModel()
        {
            Columns = new ObservableCollection<object>();
        }
    }
}