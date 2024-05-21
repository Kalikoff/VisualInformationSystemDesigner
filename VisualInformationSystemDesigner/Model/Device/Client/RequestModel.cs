using VisualInformationSystemDesigner.Model.Device.Server;

namespace VisualInformationSystemDesigner.Model.Device.Client
{
    public class RequestModel
    {
        public string Name { get; set; }

        public ServerModel SelectedServer { get; set; }
        public MethodModel SelectedMethod { get; set; }


		public RequestModel() { }
    }
}