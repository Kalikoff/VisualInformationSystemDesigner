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
			switch (ActionName)
			{
				case "Получить":
					return GetRecords();
				case "Добавить":
					return AddRecord();
				case "Изменить":
					return UpdateRecord();
				case "Удалить":
					return DeleteRecord();
				default:
					throw new InvalidOperationException("Неизвестное действие");
			}
		}

		private object GetRecords()
		{
			var records = SelectedTable.Fields.First().Data
				.Select((_, index) => SelectedTable.Fields.ToDictionary(field => field.Name, field => field.Data[index]))
				.ToList();

			foreach (var condition in Conditions)
			{
				var field = condition.Field;
				var fieldIndex = SelectedTable.Fields.IndexOf(field);
				var argumentValue = condition.Argument.Value;

				records = records.Where(record => EvaluateCondition(record[field.Name], condition.Condition, argumentValue)).ToList();
			}

			return records;
		}

		private bool EvaluateCondition(object fieldValue, string condition, object argumentValue)
		{
			var fieldValueAsString = fieldValue.ToString();

			switch (condition)
			{
				case "==":
					return Equals(fieldValueAsString, argumentValue);
				case "!=":
					return !Equals(fieldValueAsString, argumentValue);
				case "<=":
					return Compare(fieldValue, argumentValue) <= 0;
				case ">=":
					return Compare(fieldValue, argumentValue) >= 0;
				default:
					throw new InvalidOperationException("Неизвестное условие");
			}
		}

		private int Compare(object fieldValue, object conditionValue)
		{
			if (fieldValue is IComparable fieldComparable && conditionValue is IComparable conditionComparable)
			{
				return fieldComparable.CompareTo(conditionValue);
			}

			throw new InvalidOperationException("Значения не сравнимы");
		}

		private object AddRecord()
		{
			foreach (var argument in Arguments)
			{
				var field = SelectedTable.Fields.FirstOrDefault(f => f.Name == argument.Name);
				if (field != null)
				{
					field.Data.Add(argument.Value);
				}
			}

			return "Запись добавлена";
		}

		private object UpdateRecord()
		{
			var indicesToUpdate = Enumerable.Range(0, SelectedTable.Fields.First().Data.Count).ToList();

			foreach (var condition in Conditions)
			{
				var field = condition.Field;
				var fieldIndex = SelectedTable.Fields.IndexOf(field);
				indicesToUpdate = indicesToUpdate.Where(index => EvaluateCondition(field.Data[index], condition.Condition, condition.Argument.Value)).ToList();
			}

			foreach (var index in indicesToUpdate)
			{
				foreach (var argument in Arguments)
				{
					var field = SelectedTable.Fields.FirstOrDefault(f => f.Name == argument.Name);
					if (field != null)
					{
						field.Data[index] = argument.Value;
					}
				}
			}

			return "Запись обновлена";
		}

		private object DeleteRecord()
		{
			var indicesToDelete = Enumerable.Range(0, SelectedTable.Fields.First().Data.Count).ToList();

			foreach (var condition in Conditions)
			{
				var field = condition.Field;
				var fieldIndex = SelectedTable.Fields.IndexOf(field);
				indicesToDelete = indicesToDelete.Where(index => EvaluateCondition(field.Data[index], condition.Condition, condition.Argument.Value)).ToList();
			}

			foreach (var index in indicesToDelete.OrderByDescending(i => i))
			{
				foreach (var field in SelectedTable.Fields)
				{
					field.Data.RemoveAt(index);
				}
			}

			return "Запись удалена";
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