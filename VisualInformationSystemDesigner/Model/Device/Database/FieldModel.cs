﻿using System.Collections.ObjectModel;

namespace VisualInformationSystemDesigner.Model.Device.Database
{
    public class FieldModel
    {
        public string Name { get; set; } // Название
        public string DataType { get; set; } // Тип поля
        public ObservableCollection<string> Data { get; set; } // Данные

        public FieldModel()
        {
            Data = new ObservableCollection<string>();
        }
    }
}