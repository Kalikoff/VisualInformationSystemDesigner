using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VisualInformationSystemDesigner.View
{
    /// <summary>
    /// Логика взаимодействия для Workspace.xaml
    /// </summary>
    public partial class Workspace : Page
    {
        public Workspace()
        {
            InitializeComponent();
        }

        private void CanvasDevices_Drop(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(typeof(Image)))
            //{
            //    Image draggedImage = (Image)e.Data.GetData(typeof(Image));

            //    // Получаем Source изображения
            //    ImageSource imageSource = draggedImage.Source;

            //    // Создаем новый элемент Image и добавляем его на Canvas
            //    Image newImage = new Image();
            //    newImage.Source = imageSource;
            //    newImage.Width = 100; // Задаем ширину (можно настроить по своему усмотрению)
            //    newImage.Height = 100; // Задаем высоту (можно настроить по своему усмотрению)
            //    CanvasDevices.Children.Add(newImage);

            //    // Позиционируем новое изображение в месте, где оно было отпущено на Canvas
            //    Point dropPosition = e.GetPosition(CanvasDevices);
            //    Canvas.SetLeft(newImage, dropPosition.X);
            //    Canvas.SetTop(newImage, dropPosition.Y);
            //}
        }
    }
}
