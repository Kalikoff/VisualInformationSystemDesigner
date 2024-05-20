using System.Collections.ObjectModel;
using VisualInformationSystemDesigner.Model.Device.Database;

namespace VisualInformationSystemDesigner.Model.Device.Server
{
    public class MethodModel
    {
        public string Name { get; set; } // Название

        public ObservableCollection<ArgumentModel> Arguments { get; set; } // Аргументы метода
        public TableModel SelectedTable { get; set; } // Выбранная таблица
        public ObservableCollection<ConditionModel> Conditions { get; set; } // Список условий
        public string ActionName { get; set; } // Действие

        public MethodModel()
        {
            Arguments = new ObservableCollection<ArgumentModel>();
            Conditions = new ObservableCollection<ConditionModel>();
        }


        public object GetResponse()
        {
            if (ActionName == "Получить")
            {

            }
            else if (ActionName == "Добавить")
            {

            }
            else if (ActionName == "Изменить")
            {

            }
            else if (ActionName == "Удалить")
            {

            }

            return null;
        }

        private bool CheckingConditions()
        {
            foreach (var condition in Conditions)
            {
				if (!condition.Check())
                {
                    return false;
                }
            }

            return true;
        }
	}
}