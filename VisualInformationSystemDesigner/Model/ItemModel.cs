using System.Windows.Media;

namespace VisualInformationSystemDesigner.Model
{
    public class ItemModel
    {
        public string Name { get; set; }
        public ImageSource Image { get; set; }
        public ItemType ItemType { get; set; }
    }
}