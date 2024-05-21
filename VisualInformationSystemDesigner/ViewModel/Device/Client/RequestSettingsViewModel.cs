using MvvmHelpers;
using VisualInformationSystemDesigner.Model.Device.Client;

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

		public RequestSettingsViewModel(ref RequestModel request)
        {
			Request = request;
        }
    }
}