using MvvmHelpers;
using VisualInformationSystemDesigner.Model.Device.Server;

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

        public MethodSettingsViewModel(ref MethodModel method)
        {
            Method = method;
        }
    }
}