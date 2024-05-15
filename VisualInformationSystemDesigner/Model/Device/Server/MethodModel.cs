using System.Collections.ObjectModel;
using VisualInformationSystemDesigner.Model.Device.Database;

namespace VisualInformationSystemDesigner.Model.Device.Server
{
    public class MethodModel
    {
        public string Name { get; set; } // Название

        public ObservableCollection<ArgumentModel> Arguments { get; set; } // Аргументы метода
        public ObservableCollection<TableModel> SelectedTables { get; set; } // Список выбранных таблиц
        public ObservableCollection<ConditionModel> Conditions { get; set; } // Список условий

        public MethodModel()
        {
            Arguments = new ObservableCollection<ArgumentModel>();
            SelectedTables = new ObservableCollection<TableModel>();
            Conditions = new ObservableCollection<ConditionModel>();
        }
    }
}