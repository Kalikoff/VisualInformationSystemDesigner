using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model.Device;
using VisualInformationSystemDesigner.Model.Device.Server;
using VisualInformationSystemDesigner.Utilities;
using VisualInformationSystemDesigner.View.Dialogs;
using VisualInformationSystemDesigner.ViewModel.Dialogs;

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

        private ObservableCollection<MethodViewModel> _methodsVM = new(); // Список методов сервера
        public ObservableCollection<MethodViewModel> MethodsVM
        {
            get => _methodsVM;
            set
            {
                if (_methodsVM != value)
                {
                    _methodsVM = value;
                    OnPropertyChanged(nameof(MethodsVM));
                }
            }
        }

        public ICommand AddMethodCommand { get; }

        public ServerMethodsViewModel(ref DeviceModel server)
        {
            Server = (ServerModel)server;

            var databases = DeviceListLocator.Instance.Databases;


            AddMethodCommand = new RelayCommand(AddMethod);
        }

        /// <summary>
        /// Создание нового метода
        /// </summary>
        /// <param name="parameter"></param>
        private void AddMethod(object parameter)
        {
            var dialogAddDeviceViewModel = new AddItemDialogViewModel();
            var dialogAddDeviceView = new AddItemDialogView();
            dialogAddDeviceView.DataContext = dialogAddDeviceViewModel;

            if (dialogAddDeviceView.ShowDialog() == true)
            {
                Server.Methods.Add(new MethodModel { Name = dialogAddDeviceViewModel.ItemName });

                var method = Server.Methods[^1];

                MethodsVM.Add(new MethodViewModel(ref method));
            }
        }
    }
}