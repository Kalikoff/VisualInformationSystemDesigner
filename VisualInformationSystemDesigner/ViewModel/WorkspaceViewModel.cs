using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using VisualInformationSystemDesigner.Model;

namespace VisualInformationSystemDesigner.ViewModel
{
    public class WorkspaceViewModel : BaseViewModel
    {
        private ObservableCollection<ItemViewModel> _items = new();
        public ObservableCollection<ItemViewModel> Items
        {
            get => _items;
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged(nameof(Items));
                }
            }
        }

        //public ICommand CanvasDragEnterCommand { get; }
        //public ICommand CanvasDropCommand { get; }

        public WorkspaceViewModel()
        {
            ItemViewModel item1 = new ItemViewModel("PC", LoadImage("pc-icon.png"), ItemType.Device);
            ItemViewModel item2 = new ItemViewModel("Server", LoadImage("server-icon.png"), ItemType.Device);
            ItemViewModel item3 = new ItemViewModel("Database", LoadImage("database-icon.png"), ItemType.Database);

            AddDevice(item1);
            AddDevice(item2);
            AddDevice(item3);

            //CanvasDragEnterCommand = new RelayCommand(CanvasDragEnter);
            //CanvasDropCommand = new RelayCommand(CanvasDrop);
        }

        private ImageSource LoadImage(string imageName)
        {
            return new BitmapImage(new Uri($"pack://application:,,,/Resources/{imageName}"));
        }

        public void AddDevice(ItemViewModel item)
        {
            Random random = new();
            item.Top = random.Next(0, 500);
            item.Left = random.Next(0, 500);

            Items.Add(item);
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