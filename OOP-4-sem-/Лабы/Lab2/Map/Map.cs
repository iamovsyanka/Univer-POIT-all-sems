using System.Collections.Generic;
using System.Windows;

namespace MapComposite
{
    public class Map : IComponent
    {
        private readonly List<IComponent> _map = new List<IComponent>();

        public string Title { get; set; }

        public void AddComponent(IComponent component) => _map.Add(component);

        public void Draw()
        {
            MessageBox.Show(Title);
            foreach (var component in _map)
            {
                component.Draw();
            }
        }

        public IComponent Find(string title)
        {
            if (Title.Equals(title))
            {
                return this;
            }
            foreach (var component in _map)
            {
                var found = component.Find(title);
                if (found != null)
                {
                    return found;
                }
            }

            return null;
        }
    }
}
