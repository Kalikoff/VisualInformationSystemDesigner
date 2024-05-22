using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model.Device.Client;
using VisualInformationSystemDesigner.Model.Device.Server;
using VisualInformationSystemDesigner.Utilities;

namespace VisualInformationSystemDesigner.ViewModel.Device.Client
{
	class RequestSettingsViewModel : BaseViewModel
    {
		private RequestModel _request; // Ссылка на запрос
		public RequestModel Request
		{
			get => _request;
			set
			{
				if (_request != value)
				{
					_request = value;
					OnPropertyChanged(nameof(Request));
				}
			}
		}

		private ObservableCollection<ServerModel> _servers;
		public ObservableCollection<ServerModel> Servers
		{
			get => _servers;
			set
			{
				if (_servers != value)
				{
					_servers = value;
					OnPropertyChanged(nameof(Servers));
				}
			}
		}

        private string _consoleOutput;
        public string ConsoleOutput
        {
            get => _consoleOutput;
            set
            {
                if (_consoleOutput != value)
                {
                    _consoleOutput = value;
                    OnPropertyChanged(nameof(ConsoleOutput));
                }
            }
        }

		public ICommand GetResponseCommand { get; set; }
		public ICommand ClearConsoleCommand { get; set; }

        public RequestSettingsViewModel(ref RequestModel request)
        {
			Request = request;

			Servers = new ObservableCollection<ServerModel>(DeviceListLocator.Instance.Servers.Cast<ServerModel>());

			GetResponseCommand = new RelayCommand(GetResponse);
			ClearConsoleCommand = new RelayCommand(ClearConsole);
		}

		/// <summary>
		/// Получить ответ от выбранного метода
		/// </summary>
		/// <param name="parameter"></param>
		private void GetResponse(object parameter)
		{
			var response = Request.SelectedMethod.GetResponse();

			if (response is List<Dictionary<string, object>>)
			{
                foreach (var record in (List<Dictionary<string, object>>)response)
                {
                    string recordString = string.Join(", ", record.Select(kv => $"{kv.Key}: {kv.Value}"));
                    ConsoleOutput += recordString + "\n";
                }
            }
			else if (response is string)
			{
				ConsoleOutput += response + "\n";
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="parameter"></param>
        private void ClearConsole(object parameter)
        {

        }
    }
}