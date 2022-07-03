using System.Windows;

namespace Lab3
{
    public enum LifeState
    {
        Young,
        Middle,
        Old
    }

    public class Person
    {
        public LifeState State { get; set; }

        public Person(LifeState ws) => State = ws;

        public void GrowingUp()
        {
            if (State == LifeState.Young)
            {
                MessageBox.Show("30 years");
                State = LifeState.Middle;
            }
            else if (State == LifeState.Middle)
            {
                MessageBox.Show("60 years");
                State = LifeState.Old;
            }
            else if (State == LifeState.Old)
            {
                MessageBox.Show("Death");
            }
        }

        public void Memory()
        {
            if (State == LifeState.Middle)
            {
                MessageBox.Show("21 year");
                State = LifeState.Young;
            }
            else if (State == LifeState.Old)
            {
                MessageBox.Show("35 years");
                State = LifeState.Middle;
            }
        }
    }
}