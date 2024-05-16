using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model.Device.Database;
using VisualInformationSystemDesigner.Model.Device.Server;
using VisualInformationSystemDesigner.Utilities;

namespace VisualInformationSystemDesigner.ViewModel.Device.Server
{
    public class MethodSettingsViewModel : BaseViewModel
    {
        private MethodModel _method; // Ссылка на метод
        public MethodModel Method
        {
            get => _method;
            set
            {
                if (_method != value)
                {
                    _method = value;
                    OnPropertyChanged(nameof(Method));
                }
            }
        }

        private ArgumentModel _newArgument = new(); // Новый аргумент
        public ArgumentModel NewArgument
        {
            get { return _newArgument; }
            set
            {
                _newArgument = value;
                OnPropertyChanged(nameof(NewArgument));
            }
        }

        private ConditionModel _newCondition = new(); // Новое условие
        public ConditionModel NewCondition
        {
            get => _newCondition;
            set
            {
                _newCondition = value;
                OnPropertyChanged(nameof(NewCondition));
            }
        }

        public ObservableCollection<DatabaseModel> Databases { get; set; } // Список доступных баз данных

        public ICommand AddArgumentCommand { get; } // Добавить аргумент
        public ICommand RemoveArgumentCommand { get; } // Удалить аргумент

        public ICommand SelectTableCommand { get; } // Команда выбора таблицы
        public ICommand DeselectTableCommand { get; } // Команда отмены выбора таблицы

        public ICommand AddConditionCommand { get; } // Добавить условие
        public ICommand RemoveConditionCommand { get; } // Удалить условие

		public ICommand AddActionCommand { get; } // Добавить действие

		public MethodSettingsViewModel(ref MethodModel method)
        {
            Method = method;

            Databases = new ObservableCollection<DatabaseModel>(DeviceListLocator.Instance.Databases.Cast<DatabaseModel>());

            AddArgumentCommand = new RelayCommand(AddArgument);
            RemoveArgumentCommand = new RelayCommand(RemoveArgument);

            SelectTableCommand = new RelayCommand(SelectTable);
            DeselectTableCommand = new RelayCommand(DeselectTable);

            AddConditionCommand = new RelayCommand(AddCondition);
            RemoveConditionCommand = new RelayCommand(RemoveCondition);

			AddActionCommand = new RelayCommand(AddAction);
        }

        /// <summary>
        /// Добавить новый аргумент
        /// </summary>
        /// <param name="parameter"></param>
        private void AddArgument(object parameter)
        {
            if (NewArgument.Type == null || NewArgument.Name == null)
            {
                return;
            }

            Method.Arguments.Add(NewArgument);
            NewArgument = new ArgumentModel();
        }

        /// <summary>
        /// Удалить аргумент
        /// </summary>
        /// <param name="parameter"></param>
        private void RemoveArgument(object parameter)
        {
            if (parameter is ArgumentModel argumentToRemove)
            {
                Method.Arguments.Remove(argumentToRemove);
            }
        }

        /// <summary>
        /// Добавить таблицу в список выбранных
        /// </summary>
        /// <param name="parameter"></param> 
        private void SelectTable(object parameter)
        {
            if (parameter is TableModel selectedTable && !Method.SelectedTables.Contains(selectedTable))
            {
                Method.SelectedTables.Add(selectedTable);
            }
        }

        /// <summary>
        /// Удалить таблицу из списока выбранных
        /// </summary>
        /// <param name="parameter"></param>
        private void DeselectTable(object parameter)
        {
            if (parameter is TableModel selectedTable && Method.SelectedTables.Contains(selectedTable))
            {
                Method.SelectedTables.Remove(selectedTable);
            }
        }

        /// <summary>
        /// Добавить новое условие
        /// </summary>
        /// <param name="parameter"></param>
        private void AddCondition(object parameter)
        {
            if (NewCondition.Table == null || NewCondition.Field == null || NewCondition.Condition == null || NewCondition.Argument == null)
            {
                return;
            }

            Method.Conditions.Add(NewCondition);
            NewCondition = new ConditionModel();
        }

        /// <summary>
        /// Удалить условие
        /// </summary>
        /// <param name="parameter"></param>
        private void RemoveCondition(object parameter)
        {
            if (parameter is ConditionModel conditionToRemove)
            {
                Method.Conditions.Remove(conditionToRemove);
            }
        }

		/// <summary>
		/// Добавить действие
		/// </summary>
		/// <param name="parameter"></param>
		private void AddAction(object parameter)
		{
            Method.Actions.Add(new ActionModel());
		}
	}
}