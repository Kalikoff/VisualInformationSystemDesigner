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

        /// <summary>
        /// Получить ответ от сервера
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
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
                    throw new InvalidOperationException("Неизвестное действие!\n");
            }
        }

        /// <summary>
        /// Получить записи из таблицы
        /// </summary>
        /// <returns></returns>
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

                records = records.Where(record => EvaluateCondition(record[field.Name], condition, argumentValue)).ToList();
            }

            if (records.Count != 0)
            {
                return records;
            }

            return "Записи не найдены!";
        }

        /// <summary>
        /// Сравнение всех записей с значением аргумента
        /// </summary>
        /// <param name="fieldValue">Значение из поля</param>
        /// <param name="condition">Тип условия</param>
        /// <param name="argumentValue">Значеие аргумента</param>
        /// <returns>Статус</returns>
        /// <exception cref="InvalidOperationException">Ошибка данных</exception>
        private bool EvaluateCondition(string fieldValue, ConditionModel condition, string argumentValue)
        {
            if (condition.Argument.DataType == "String" && (condition.Condition == "<" || condition.Condition == ">"))
            {
                throw new InvalidOperationException("Несравнимые типы данных!\n");
            }

            switch (condition.Condition)
            {
                case "==":
                    return Equals(fieldValue, argumentValue);
                case "!=":
                    return !Equals(fieldValue, argumentValue);
                case "<":
                    return Compare(fieldValue, condition, argumentValue) < 0;
                case ">":
                    return Compare(fieldValue, condition, argumentValue) > 0;
                default:
                    throw new InvalidOperationException("Неизвестное условие!\n");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldValue"></param>
        /// <param name="conditionValue"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private int Compare(string fieldValue, ConditionModel condition, string conditionValue)
        {
            object fieldValueAsNumber = null;
            object conditionValueAsNumber = null;

            if (condition.Argument.DataType == "Int")
            {
                fieldValueAsNumber = Convert.ToInt32(fieldValue);
                conditionValueAsNumber = Convert.ToInt32(conditionValue);
            }
            else if (condition.Argument.DataType == "Double")
            {
                fieldValueAsNumber = Convert.ToDouble(fieldValue);
                conditionValueAsNumber = Convert.ToDouble(conditionValue);
            }

            if (fieldValueAsNumber is IComparable fieldComparable && conditionValueAsNumber is IComparable conditionComparable)
            {
                return fieldComparable.CompareTo(conditionComparable);
            }

            throw new InvalidOperationException("Значения не сравнимы!\n");
        }

        /// <summary>
        /// Добавить запись
        /// </summary>
        /// <returns></returns>
        private object AddRecord()
        {
            // Проверяем наличие всех полей с названиями аргументов
            var missingFields = Arguments.Where(argument =>
                SelectedTable.Fields.All(field => field.Name != argument.Name)).ToList();

            if (missingFields.Any())
            {
                // Если найдены отсутствующие поля, возвращаем строку с их перечислением
                var missingFieldNames = string.Join(", ", missingFields.Select(field => field.Name));
                return $"Неверные аргументы: {missingFieldNames}!\n";
            }

            // Проверяем, что количество аргументов не превышает количество полей
            if (Arguments.Count > SelectedTable.Fields.Count)
            {
                return $"Количество аргументов превышает количество полей в таблице!\n";
            }

            var result = "";

            foreach (var argument in Arguments)
            {
                var field = SelectedTable.Fields.FirstOrDefault(f => f.Name == argument.Name);

                if (field != null)
                {
                    field.Data.Add(argument.Value);

                    result += $"{argument.Name}: {argument.Value}; ";
                }
            }	

            return $"Запись {result}добавлена!\n";
        }

        private object UpdateRecord()
        {
            var indicesToUpdate = Enumerable.Range(0, SelectedTable.Fields.First().Data.Count).ToList();

            foreach (var condition in Conditions)
            {
                var field = condition.Field;
                var fieldIndex = SelectedTable.Fields.IndexOf(field);
                indicesToUpdate = indicesToUpdate.Where(index => EvaluateCondition(field.Data[index], condition, condition.Argument.Value)).ToList();
            }

            var result = "";
            foreach (var index in indicesToUpdate)
            {
                foreach (var argument in Arguments)
                {
                    var field = SelectedTable.Fields.FirstOrDefault(f => f.Name == argument.Name);
                    if (field != null)
                    {
                        field.Data[index] = argument.Value;
                        result += $"{argument.Name}: {argument.Value}; ";
                    }
                }
            }

            if (result != string.Empty)
            {
                return result;
            }

            return "Записи для редактирования не найдены!";
        }

        private object DeleteRecord()
        {
            var indicesToDelete = Enumerable.Range(0, SelectedTable.Fields.First().Data.Count).ToList();

            foreach (var condition in Conditions)
            {
                var field = condition.Field;
                var fieldIndex = SelectedTable.Fields.IndexOf(field);
                indicesToDelete = indicesToDelete.Where(index => EvaluateCondition(field.Data[index], condition, condition.Argument.Value)).ToList();
            }

            var result = "";
            foreach (var index in indicesToDelete.OrderByDescending(i => i))
            {
                foreach (var field in SelectedTable.Fields)
                {
                    result += $"{field.Name}: {field.Data[index]}; ";
                    field.Data.RemoveAt(index);
                }
            }

            if (result != string.Empty)
            {
                return result;
            }

            return "Записи для удаления не найдены!";
        }
    }
}