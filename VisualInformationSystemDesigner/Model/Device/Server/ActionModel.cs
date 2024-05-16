using VisualInformationSystemDesigner.Model.Device.Database;

namespace VisualInformationSystemDesigner.Model.Device.Server
{
	public class ActionModel
	{
		public TableModel Table { get; set; } // Таблица с которой происходит действие
		public string Action {  get; set; } // Действие

		public ActionModel() { }
	}
}