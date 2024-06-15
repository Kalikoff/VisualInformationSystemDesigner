using System.Collections.ObjectModel;
using VisualInformationSystemDesigner.View.Device.Client;
using VisualInformationSystemDesigner.ViewModel.Device.Client;

namespace VisualInformationSystemDesigner.Model.Device.Client
{
    public class ClientModel : DeviceModel
    {
        public ObservableCollection<RequestModel> Requests { get; set; } // Список запросов

        public ClientModel()
        {
            Requests = new ObservableCollection<RequestModel>();
        }

        /// <summary>
        /// Отобразить окно с информацией о клиенте
        /// </summary>
        /// <param name="device">Ссылка на клиент</param>
        public override void ShowDeviceInformation(ref DeviceModel device)
        {
            var clientRequestsViewModel = new ClientRequestsViewModel(ref device);
            var clientRequestsView = new ClientRequestsView();
            clientRequestsView.DataContext = clientRequestsViewModel;
            clientRequestsView.Show();
        }
    }
}