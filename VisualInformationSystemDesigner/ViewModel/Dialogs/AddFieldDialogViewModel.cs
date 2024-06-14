using MvvmHelpers;
using System.Windows.Input;
using System.Windows;
using VisualInformationSystemDesigner.Utilities;

namespace VisualInformationSystemDesigner.ViewModel.Dialogs
{
    public class AddFieldDialogViewModel : BaseViewModel
    {
        private string _itemName;
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

        private string _itemDataType;
        public string ItemDataType
        {
            get => _itemDataType;
            set
            {
                if (_itemDataType != value)
                {
                    _itemDataType = value;
                    OnPropertyChanged(nameof(ItemDataType));
                }
            }
        }

        public ICommand AddItemCommand { get; }
        public ICommand CancelCommand { get; }

        public AddFieldDialogViewModel()
        {
            AddItemCommand = new RelayCommand(AddItem);
            CancelCommand = new RelayCommand(Cancel);
        }

        public void AddItem(object parameter)
        {
            var window = parameter as Window;

            if (window != null)
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
