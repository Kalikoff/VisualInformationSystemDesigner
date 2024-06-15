using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Windows;
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

        public ICommand DeleteDeviceCommand { get; }
        public ICommand AddMethodCommand { get; }

        public ServerMethodsViewModel(ref DeviceModel server)
        {
            Server = (ServerModel)server;

            // Отображение всех существующих методов сервера
            for (int i = 0; i < Server.Methods.Count; i++)
            {
                var method = Server.Methods[i];
                MethodsVM.Add(new MethodViewModel(ref method, this));
            }

            DeleteDeviceCommand = new RelayCommand<Window>(DeleteDevice);
            AddMethodCommand = new RelayCommand(AddMethod);
        }

        /// <summary>
        /// Удаление представления модели метода
        /// </summary>
        /// <param name="method"></param>
        /// <param name="methodVM"></param>
        public void DeleteMethod(MethodModel method, MethodViewModel methodVM)
        {
            _server.Methods.Remove(method);
            _methodsVM.Remove(methodVM);
        }

        /// <summary>
        /// Удалить это устройство
        /// </summary>
        /// <param name="window">Экземпляр текущего окна</param>
        private void DeleteDevice(Window window)
        {
            DeviceListLocator.Instance.Servers.Remove(Server);
            var databaseVM = DeviceListLocator.Instance.ServersVM.First(d => d.Device == Server);
            DeviceListLocator.Instance.ServersVM.Remove(databaseVM);

            window.Close();
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

                MethodsVM.Add(new MethodViewModel(ref method, this));
            }
        }
    }
}