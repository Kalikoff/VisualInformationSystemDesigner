using MvvmHelpers;
using System.Collections.ObjectModel;
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

		public RequestSettingsViewModel(ref RequestModel request)
        {
			Request = request;

			Servers = new ObservableCollection<ServerModel>(DeviceListLocator.Instance.Servers.Cast<ServerModel>());
		}
    }
}