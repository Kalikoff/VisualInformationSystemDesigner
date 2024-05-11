﻿using MvvmHelpers;
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
        private DatabaseModel _database; // Ссылка на базу данных
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

        private ObservableCollection<TableViewModel> _tablesVM = new(); // Список таблиц базы данных
        public ObservableCollection<TableViewModel> TablesVM
        {
            get => _tablesVM;
            set
            {
                if (_tablesVM != value)
                {
                    _tablesVM = value;
                    OnPropertyChanged(nameof(TablesVM));
                }
            }
        }

        public ICommand AddTableCommand { get; }

        public DatabaseTablesViewModel(ref DeviceModel database)
        {
            Database = (DatabaseModel)database;

            // Получение всех таблиц из БД
            for (int i = 0; i < Database.Tables.Count; i++)
            {
                var table = Database.Tables[i];
                TablesVM.Add(new TableViewModel(ref table));
            }

            AddTableCommand = new RelayCommand(AddTable);
        }

        /// <summary>
        /// Создание новой таблицы
        /// </summary>
        /// <param name="parameter"></param>
        private void AddTable(object parameter)
        {
            var dialogAddDeviceViewModel = new AddItemDialogViewModel();
            var dialogAddDeviceView = new AddItemDialogView();
            dialogAddDeviceView.DataContext = dialogAddDeviceViewModel;

            if (dialogAddDeviceView.ShowDialog() == true)
            {
                // Тестовый код
                Database.Tables.Add(new TableModel
                {
                    Name = dialogAddDeviceViewModel.ItemName,
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
                });

                //Database.Tables.Add(new TableModel { Name = dialogAddDeviceViewModel.ItemName }); // Добавление таблицы

                var table = Database.Tables[^1];

                TablesVM.Add(new TableViewModel(ref table));
            }
        }
    }
}