﻿using MvvmHelpers;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model.Device.Client;
using VisualInformationSystemDesigner.Utilities;
using VisualInformationSystemDesigner.View.Device.Client;

namespace VisualInformationSystemDesigner.ViewModel.Device.Client
{
	class RequestViewModel : BaseViewModel
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

		public ICommand ShowRequestsWindowCommand { get; }

		public RequestViewModel(ref RequestModel request)
		{
			Request = request;

			ShowRequestsWindowCommand = new RelayCommand(ShowRequestsWindow);
		}

		/// <summary>
		/// Отображение окна с настройками Запроса
		/// </summary>
		/// <param name="parameter"></param>
		public void ShowRequestsWindow(object parameter)
		{
			var requestSettingsViewModel = new RequestSettingsViewModel(ref _request);
			var requestSettingsView = new RequestSettingsView();
			requestSettingsView.DataContext = requestSettingsViewModel;
			requestSettingsView.Show();
		}
	}
}