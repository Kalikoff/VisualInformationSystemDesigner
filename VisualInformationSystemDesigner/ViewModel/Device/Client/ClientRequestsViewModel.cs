using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model.Device;
using VisualInformationSystemDesigner.Model.Device.Client;
using VisualInformationSystemDesigner.Utilities;
using VisualInformationSystemDesigner.View.Dialogs;
using VisualInformationSystemDesigner.ViewModel.Dialogs;

namespace VisualInformationSystemDesigner.ViewModel.Device.Client
{
    class ClientRequestsViewModel : BaseViewModel
    {
        private ClientModel _client; // Ссылка на клиента
        public ClientModel Client
        {
            get => _client;
            set
            {
                if (_client != value)
                {
                    _client = value;
                    OnPropertyChanged(nameof(Client));
                }
            }
        }

        private ObservableCollection<RequestViewModel> _requestsVM = new(); // Список запросов клиента
        public ObservableCollection<RequestViewModel> RequestsVM
        {
            get => _requestsVM;
            set
            {
                if (_requestsVM != value)
                {
                    _requestsVM = value;
                    OnPropertyChanged(nameof(RequestsVM));
                }
            }
        }

        public ICommand DeleteDeviceCommand { get; }
        public ICommand AddRequestCommand { get; }

        public ClientRequestsViewModel(ref DeviceModel client)
        {
            Client = (ClientModel)client;

            // Получение всех запросов из Клиента
            for (int i = 0; i < Client.Requests.Count; i++)
            {
                var request = Client.Requests[i];
                RequestsVM.Add(new RequestViewModel(ref request, this));
            }

            DeleteDeviceCommand = new RelayCommand<Window>(DeleteDevice);
            AddRequestCommand = new RelayCommand(AddRequest);
        }

        /// <summary>
        /// Удаление представления модели запроса
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestVM"></param>
        public void DeleteRequest(RequestModel request, RequestViewModel requestVM)
        {
            _client.Requests.Remove(request);
            _requestsVM.Remove(requestVM);
        }

        /// <summary>
        /// Удалить это устройство
        /// </summary>
        /// <param name="window">Экземпляр текущего окна</param>
        private void DeleteDevice(Window window)
        {
            DeviceListLocator.Instance.Clients.Remove(Client);
            var databaseVM = DeviceListLocator.Instance.ClientsVM.First(d => d.Device == Client);
            DeviceListLocator.Instance.ClientsVM.Remove(databaseVM);

            window.Close();
        }

        /// <summary>
        /// Создание нового метода
        /// </summary>
        /// <param name="parameter"></param>
        private void AddRequest(object parameter)
        {
            var dialogAddDeviceViewModel = new AddItemDialogViewModel();
            var dialogAddDeviceView = new AddItemDialogView();
            dialogAddDeviceView.DataContext = dialogAddDeviceViewModel;

            if (dialogAddDeviceView.ShowDialog() == true)
            {
                Client.Requests.Add(new RequestModel() { Name = dialogAddDeviceViewModel.ItemName}); // Добавление запроса

                var request = Client.Requests[^1];

                RequestsVM.Add(new RequestViewModel(ref request, this));
            }
        }
    }
}