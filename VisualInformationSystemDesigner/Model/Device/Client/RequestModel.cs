using VisualInformationSystemDesigner.Model.Device.Server;

namespace VisualInformationSystemDesigner.Model.Device.Client
{
    public class RequestModel
    {
        public string Name { get; set; }

        public ServerModel SelectedServer { get; set; } // Не обязательное поле, можно вынести в ViewModel
        public MethodModel SelectedMethod { get; set; }


		public RequestModel() { }
    }
}