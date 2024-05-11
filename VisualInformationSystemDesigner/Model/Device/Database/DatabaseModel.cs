using System.Collections.ObjectModel;
using VisualInformationSystemDesigner.View.Device.Database;
using VisualInformationSystemDesigner.ViewModel.Device.Database;

namespace VisualInformationSystemDesigner.Model.Device.Database
{
    public class DatabaseModel : DeviceModel
    {
        public ObservableCollection<TableModel> Tables { get; set; } // Таблицы

        public DatabaseModel()
        {
            Tables = new ObservableCollection<TableModel>();
        }

        /// <summary>
        /// Отобразить окно с информацией о базе данных
        /// </summary>
        /// <param name="device">Ссылка на базу данных</param>
        public override void ShowDeviceInformation(ref DeviceModel device)
        {
            var databaseTablesViewModel = new DatabaseTablesViewModel(ref device);
            var databaseTablesView = new DatabaseTablesView();
            databaseTablesView.DataContext = databaseTablesViewModel;
            databaseTablesView.Show();
        }
    }
}