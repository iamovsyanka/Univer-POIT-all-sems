using System.Windows;

namespace Adapter
{
    public class MiniPig : IMiniPig
    {
        public void MiniSay() => MessageBox.Show("Я маленькая свинка и говорю 'хрю!'");
    }
}
