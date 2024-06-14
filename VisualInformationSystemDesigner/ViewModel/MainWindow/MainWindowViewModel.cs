using MvvmHelpers;
using System.Windows.Controls;
using VisualInformationSystemDesigner.View.Workspace;

namespace VisualInformationSystemDesigner.ViewModel.MainWindow
{
    public class MainWindowViewModel : BaseViewModel
    {
        public Page CurrentPage { get; set; }

        public MainWindowViewModel()
        {
            CurrentPage = new WorkspaceView();
        }
    }
}