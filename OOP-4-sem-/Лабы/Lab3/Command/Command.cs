using System.Windows;

namespace Lab3
{
    public interface ICommand
    {
        void Execute();
    }

    public class Invoker
    {
        ICommand command;

        public void SetCommand(ICommand command) => this.command = command;

        public void Run() => command.Execute();
    }

    public class JumpCommand : ICommand
    {
        public void Execute() => MessageBox.Show("Jump");
    }

    public class RunCommand : ICommand
    {
        public void Execute() => MessageBox.Show("Run");
    }
}
