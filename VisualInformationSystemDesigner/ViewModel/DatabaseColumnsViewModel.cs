using MvvmHelpers;
using VisualInformationSystemDesigner.Model.Device.Database;

namespace VisualInformationSystemDesigner.ViewModel
{
    public class DatabaseColumnsViewModel : BaseViewModel
    {
        public TableModel Table { get; set; }

        public DatabaseColumnsViewModel(ref TableModel table)
        {
            Table = table;

        }
    }
}