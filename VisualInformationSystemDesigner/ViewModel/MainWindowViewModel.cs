using MvvmHelpers;
using System.Windows.Controls;
using VisualInformationSystemDesigner.View;

namespace VisualInformationSystemDesigner.ViewModel
{
	public class MainWindowViewModel : BaseViewModel
	{
		public Page CurrentPage { get; set; }

		public MainWindowViewModel()
		{
			CurrentPage = new HomeView();
		}
	}
}