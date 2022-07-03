using System.Windows;

namespace Adapter
{
    public class Pig : IPig
    {
        public void Say() => MessageBox.Show("Я большая свинья и говорю 'ХРЮ'");
    }
}
