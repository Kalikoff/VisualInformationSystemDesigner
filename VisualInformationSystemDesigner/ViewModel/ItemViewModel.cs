using MvvmHelpers;
using System.Windows.Input;
using System.Windows.Media;
using VisualInformationSystemDesigner.Model;
using VisualInformationSystemDesigner.Utilities;
using VisualInformationSystemDesigner.View;

namespace VisualInformationSystemDesigner.ViewModel
{
    public class ItemViewModel : BaseViewModel
    {
        private ItemModel _item; // Данные устройства
        private double _left; // Позиция на форме по X
        private double _top; // Позиция на форме по Y
        private bool _powerStatus; // Текущий статус устройства

        public ItemModel Item
        {
            get => _item;
            set
            {
                if (_item != value)
                {
                    _item = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Left
        {
            get => _left;
            set
            {
                if (_left != value)
                {
                    _left = value;
                    OnPropertyChanged(nameof(Left));
                }
            }
        }

        public double Top
        {
            get => _top;
            set
            {
                if (_top != value)
                {
                    _top = value;
                    OnPropertyChanged(nameof(Top));
                }
            }
        }

        public bool PowerStatus
        {
            get => _powerStatus;
            set
            {
                if (_powerStatus != value)
                {
                    _powerStatus = value;
                }
            }
        }

        public ItemViewModel(string name, ImageSource image, ItemType itemType)
        {
            if (itemType == ItemType.Device)
            {
                Item = new DeviceModel();
            }
            else if (itemType == ItemType.Database)
            {
                Item = new DatabaseModel();
            }

            Item.Name = name;
            Item.Image = image;
            Item.ItemType = itemType;

            ShowDeviceInfoWindowCommand = new RelayCommand(ShowDeviceInfoWindow);
        }

        public ICommand ShowDeviceInfoWindowCommand { get; }

        public void ShowDeviceInfoWindow(object obj)
        {
            if (Item.ItemType == ItemType.Device)
            {
                var deviceInfoViewModel = new DeviceInfoViewModel(ref _item);
                var deviceInfoView = new DeviceInfoView();
                deviceInfoView.DataContext = deviceInfoViewModel;
                deviceInfoView.Show();
            }
            else if (Item.ItemType == ItemType.Database)
            {
                var databaseInfoViewModel = new DatabaseInfoViewModel(ref _item);
                var databaseInfoView = new DatabaseInfoView();
                databaseInfoView.DataContext = databaseInfoViewModel;
                databaseInfoView.Show();
            }
        }
    }
}