using MvvmHelpers;
using VisualInformationSystemDesigner.Model.Device;
using VisualInformationSystemDesigner.Model.Device.Server;

namespace VisualInformationSystemDesigner.ViewModel.Device.Server
{
    public class ServerMethodsViewModel : BaseViewModel
    {
        private ServerModel _server;
        public ServerModel Server
        {
            get => _server;
            set
            {
                if (_server != value)
                {
                    _server = value;
                    OnPropertyChanged(nameof(Server));
                }
            }
        }

        public ServerMethodsViewModel(ref DeviceModel server)
        {
            Server = (ServerModel)server;
        }
    }
}