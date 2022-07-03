using System.Windows;


namespace Lab3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Run(object sender, RoutedEventArgs e)
        {
            var invoker = new Invoker();
            invoker.SetCommand(new JumpCommand());
            invoker.Run();

            invoker.SetCommand(new RunCommand());
            invoker.Run();

            var water = new Person(LifeState.Young);
            water.GrowingUp();
            water.GrowingUp();
            water.Memory();
        }
    }
}
