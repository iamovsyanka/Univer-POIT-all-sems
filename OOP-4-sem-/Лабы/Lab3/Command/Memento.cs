using System;
using System.Collections.Generic;
using System.Windows;

namespace Lab3
{
    public class Hero
    {
        private int cash;
        private DateTime date;

        public void RaiseCash() => cash += 10;

        public HeroMemento SaveState()
        {
            date = DateTime.Now;
            MessageBox.Show($"Сохранение cocтояния: {cash} $, {date} date");

            return new HeroMemento(cash, date);
        }

        public void RestoreState(HeroMemento memento)
        {
            cash = memento.Cash;
            date = memento.Date;
            MessageBox.Show($"Восстановление состояния: {cash} $, {date} date");
        }
    }

    public class HeroMemento
    {
        public int Cash { get; private set; }

        public DateTime Date { get; private set; }

        public HeroMemento(int cash, DateTime date)
        {
            Cash = cash;
            Date = date;
        }
    }
    public class Restorer
    {
        public Stack<HeroMemento> History { get; private set; }

        public Restorer() => History = new Stack<HeroMemento>();
    }
}
