using System.Windows;

namespace MapComposite
{
    public class MapComponent : IComponent
    {
        public string Title { get; set; }

        public void Draw() => MessageBox.Show(Title);

        public IComponent Find(string title) => Title == title ? this : null;
    }
}
