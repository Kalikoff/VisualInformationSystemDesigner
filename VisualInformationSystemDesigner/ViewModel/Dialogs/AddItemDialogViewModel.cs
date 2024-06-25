using MvvmHelpers;
using System.Windows;
using System.Windows.Input;
using VisualInformationSystemDesigner.Utilities;

namespace VisualInformationSystemDesigner.ViewModel.Dialogs
{
    public class AddItemDialogViewModel : BaseViewModel
    {
        private string _itemName = string.Empty;
        public string ItemName
        {
            get => _itemName;
            set
            {
                if (_itemName != value)
                {
                    _itemName = value;
                    OnPropertyChanged(nameof(ItemName));
                }
            }
        }

        public ICommand AddItemCommand { get; }

        public ICommand CancelCommand { get; }

        public AddItemDialogViewModel()
        {
            AddItemCommand = new RelayCommand(AddItem);
            CancelCommand = new RelayCommand(Cancel);
        }

        public void AddItem(object parameter)
        {
            var window = parameter as Window;

            if (window != null && ItemName != string.Empty)
            {
                window.DialogResult = true;
            }
        }

        private void Cancel(object parameter)
        {
            var window = parameter as Window;

            if (window != null)
            {
                window.DialogResult = false;
            }
        }
    }
}