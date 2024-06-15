using MvvmHelpers;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model.Device.Server;
using VisualInformationSystemDesigner.Utilities;
using VisualInformationSystemDesigner.View.Device.Server;

namespace VisualInformationSystemDesigner.ViewModel.Device.Server
{
    public class MethodViewModel : BaseViewModel
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

        private ServerMethodsViewModel _serverMethodsVM;

        public ICommand ShowMethodSettingsWindowCommand { get; }

        public MethodViewModel(ref MethodModel method, ServerMethodsViewModel serverMethodsVM)
        {
            Method = method;
            _serverMethodsVM = serverMethodsVM;

            ShowMethodSettingsWindowCommand = new RelayCommand(ShowMethodSettingsWindow);
        }

        public void DeleteMethod()
        {
            _serverMethodsVM.DeleteMethod(Method, this);
        }

        /// <summary>
        /// Отображение окна с настройками метода
        /// </summary>
        /// <param name="parameter"></param>
        public void ShowMethodSettingsWindow(object parameter)
        {
            var methodSettingsViewModel = new MethodSettingsViewModel(ref _method, this);
            var methodSettingsView = new MethodSettingsView();
            methodSettingsView.DataContext = methodSettingsViewModel;
            methodSettingsView.Show();
        }
    }
}