using VisualInformationSystemDesigner.Model.Device.Database;

namespace VisualInformationSystemDesigner.Model.Device.Server
{
    public class ConditionModel
    {
        //public TableModel Table { get; set; } // Таблица из который берётся поле
        public FieldModel Field { get; set; } // Поле
        public string Condition { get; set; } // Условие
        public ArgumentModel Argument { get; set; } // Аргумент

        public ConditionModel() { }

		public bool Check()
        {
			bool result = false;

			foreach (var data in Field.Data)
			{
				if (Condition == "==")
				{
					if (data == Argument.Value)
					{
						return true;
					}
				}
				else if (Condition == "!=")
				{
					if (data != Argument.Value)
					{
						return true;
					}
				}
				else if (Condition == ">=")
				{
					if (Argument.DataType == DataType.Int)
					{
						if (Convert.ToInt32(data) >= Convert.ToInt32(Argument.Value))
						{
							result = true;
						}
					}
					else if (Argument.DataType == DataType.Double)
					{
						if (Convert.ToDouble(data) >= Convert.ToDouble(Argument.Value))
						{
							result = true;
						}
					}
				}
				else if (Condition == "<=")
				{
					if (Argument.DataType == DataType.Int)
					{
						if (Convert.ToInt32(data) <= Convert.ToInt32(Argument.Value))
						{
							result = true;
						}
					}
					else if (Argument.DataType == DataType.Double)
					{
						if (Convert.ToDouble(data) <= Convert.ToDouble(Argument.Value))
						{
							result = true;
						}
					}
				}
			}

			return result;
		}
	}
}