using System.Windows.Media;

namespace VisualInformationSystemDesigner.Model
{
	public class Device
	{
		private string _name; // Название
		private ImageSource _image; // Иконка
		private string _source; // Код устройства

		public string Name
		{
			get => _name;
			set
			{
				if (_name != value)
				{
					_name = value;
				}
			}
		}

		public ImageSource Image
		{
			get => _image;
			set
			{
				if (_image != value)
				{
					_image = value;
				}
			}
		}

		public string Source
		{
			get => _source;
			set
			{
				if (_source != value)
				{
					_source = value;
				}
			}
		}
	}
}