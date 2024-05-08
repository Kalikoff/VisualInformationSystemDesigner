using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model.Device;
using VisualInformationSystemDesigner.Model.Device.Database;
using VisualInformationSystemDesigner.Utilities;
using VisualInformationSystemDesigner.View.Dialogs;
using VisualInformationSystemDesigner.ViewModel.Dialogs;

namespace VisualInformationSystemDesigner.ViewModel.Device.Database
{
    public class DatabaseTablesViewModel : BaseViewModel
    {
        private DatabaseModel _database;
        public DatabaseModel Database
        {
            get => _database;
            set
            {
                if (_database != value)
                {
                    _database = value;
                    OnPropertyChanged(nameof(Database));
                }
            }
        }

        public ICommand AddTableCommand { get; }
        public ICommand ShowColumnsListWindowCommand { get; }



        public DatabaseTablesViewModel(ref DeviceModel database)
        {
            Database = (DatabaseModel)database;

            AddTableCommand = new RelayCommand(AddTable);
            //ShowColumnsListWindowCommand = new RelayCommand(ShowColumnsListWindow);
        }



        private void AddTable(object parameter)
        {
            var dialogAddDeviceViewModel = new AddItemDialogViewModel();
            var dialogAddDeviceView = new AddItemDialogView();
            dialogAddDeviceView.DataContext = dialogAddDeviceViewModel;

            if (dialogAddDeviceView.ShowDialog() == true)
            {
                Database.Tables.Add(new TableViewModel(new TableModel
                {
                    Name = "Table 1",
                    ColumnsName = new ObservableCollection<string>
                    {
                        "Id",
                        "Name",
                        "Role"
                    },
                    Rows = new ObservableCollection<RowModel>
                    {
                        new RowModel
                        {
                            Columns = new ObservableCollection<object>
                            {
                                "1",
                                "Masha",
                                "Admin"
                            },
                        },
                        new RowModel
                        {
                            Columns = new ObservableCollection<object>
                            {
                                "2",
                                "Misha"
                            }
                        },
                        new RowModel
                        {
                            Columns = new ObservableCollection<object>
                            {
                                "3",
                                "Roma"
                            }
                        }
                    }
                }));
                //var table = new TableModel { Name = dialogAddDeviceViewModel.ItemName };
                //Database.Tables.Add(table);
            }
        }



        public void ShowColumnsListWindow(object obj)
        {

        }
    }
}