using MvvmHelpers;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using VisualInformationSystemDesigner.Model.Device;
using VisualInformationSystemDesigner.Model.Device.Client;
using VisualInformationSystemDesigner.Model.Device.Database;
using VisualInformationSystemDesigner.Model.Device.Server;
using VisualInformationSystemDesigner.Utilities;
using VisualInformationSystemDesigner.View;

namespace VisualInformationSystemDesigner.ViewModel
{
    public class DeviceViewModel : BaseViewModel
    {
        private DeviceModel _device; // Устройство
        public DeviceModel Device
        {
            get => _device;
            set
            {
                if (_device != value)
                {
                    _device = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ShowDeviceInfoWindowCommand { get; }



        public DeviceViewModel(string name, DeviceType itemType)
        {
            if (itemType == DeviceType.Database)
            {
                Device = new DatabaseModel();
                Device.Image = LoadImage("database-icon.png");
            }
            else if (itemType == DeviceType.Server)
            {
                Device = new ServerModel();
                Device.Image = LoadImage("server-icon.png");
            }
            else if (itemType == DeviceType.Client)
            {
                Device = new ClientModel();
                Device.Image = LoadImage("client-icon.png");
            }

            Device.Name = name;
            Device.DeviceType = itemType;

            ShowDeviceInfoWindowCommand = new RelayCommand(ShowDeviceInfoWindow);
        }



        public void ShowDeviceInfoWindow(object obj)
        {
            if (Device.DeviceType == DeviceType.Database)
            {
                var databaseInfoViewModel = new DatabaseInfoViewModel(ref _device);
                var databaseInfoView = new DatabaseInfoView();
                databaseInfoView.DataContext = databaseInfoViewModel;
                databaseInfoView.Show();
            }
            else if (Device.DeviceType == DeviceType.Server)
            {
                //var databaseInfoViewModel = new DatabaseInfoViewModel(ref _item);
                //var databaseInfoView = new DatabaseInfoView();
                //databaseInfoView.DataContext = databaseInfoViewModel;
                //databaseInfoView.Show();
            }
            else if (Device.DeviceType == DeviceType.Client)
            {
                //var databaseInfoViewModel = new DatabaseInfoViewModel(ref _item);
                //var databaseInfoView = new DatabaseInfoView();
                //databaseInfoView.DataContext = databaseInfoViewModel;
                //databaseInfoView.Show();
            }
        }



        private ImageSource LoadImage(string imageName)
        {
            return new BitmapImage(new Uri($"pack://application:,,,/Resources/{imageName}"));
        }
    }
}