using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VisualInformationSystemDesigner.ViewModel
{
    public class WorkspaceViewModel : BaseViewModel
    {
        private ObservableCollection<DeviceViewModel> _devices = new();
        public ObservableCollection<DeviceViewModel> Devices
        {
            get => _devices;
            set
            {
                if (_devices != value)
                {
                    _devices = value;
                    OnPropertyChanged(nameof(Devices));
                }
            }
        }

        //public ICommand CanvasDragEnterCommand { get; }
        //public ICommand CanvasDropCommand { get; }

        public WorkspaceViewModel()
        {
            DeviceViewModel device1 = new DeviceViewModel("PC", LoadImage("pc-icon.png"));
            DeviceViewModel device2 = new DeviceViewModel("Server", LoadImage("server-icon.png"));
            DeviceViewModel device3 = new DeviceViewModel("Database", LoadImage("database-icon.png"));

            AddDevice(device1);
            AddDevice(device2);
            AddDevice(device3);

            //CanvasDragEnterCommand = new RelayCommand(CanvasDragEnter);
            //CanvasDropCommand = new RelayCommand(CanvasDrop);
        }

        private ImageSource LoadImage(string imageName)
        {
            return new BitmapImage(new Uri($"pack://application:,,,/Resources/{imageName}"));
        }

        public void AddDevice(DeviceViewModel device)
        {
            Random random = new();
            device.Top = random.Next(0, 500);
            device.Left = random.Next(0, 500);

            Devices.Add(device);
        }

        private void CanvasDragEnter(object obj)
        {
            
        }

        private void CanvasDrop(object obj)
        {
            //if (obj is DragEventArgs e && e.Data.GetDataPresent(typeof(BitmapImage)))
            //{
            //    Canvas canvas = e.Source as Canvas;
            //    BitmapImage imageSource = e.Data.GetData(typeof(BitmapImage)) as BitmapImage;

            //    // Create a new Image
            //    Image droppedImage = new Image();
            //    droppedImage.Source = imageSource;
            //    droppedImage.Width = 100;
            //    droppedImage.Height = 100;

            //    // Get the drop position
            //    Point position = e.GetPosition(canvas);

            //    // Set the position of the dropped image
            //    Canvas.SetLeft(droppedImage, position.X);
            //    Canvas.SetTop(droppedImage, position.Y);

            //    // Add the dropped image to the Canvas
            //    canvas.Children.Add(droppedImage);
            //}
        }
    }
}