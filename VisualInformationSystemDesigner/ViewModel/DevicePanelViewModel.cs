using MvvmHelpers;
using System.Windows.Input;
using System.Windows;

namespace VisualInformationSystemDesigner.ViewModel
{
	public class DevicePanelViewModel : BaseViewModel
	{
		public DevicePanelViewModel()
		{

		}

        private void Device_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (sender is Image image)
            //{
            //    DragDrop.DoDragDrop(image, image, DragDropEffects.Copy);
            //}

        }
    }
}