namespace Lab9
{
    public class Game
    {
        public delegate int MyGame(Game value1, int value2);
        public event MyGame AttackEvent;
        public event MyGame TreatEvent;
        public int Hp { get; set; }
        public int HealingValue { get; set; }
        public string Name { get; set; }
        public int AttackValue { get; set; }

        public void Attack(Game person2) => person2.Hp = person2.AttackEvent(person2, AttackValue);
        
        public void Heal() => Hp = TreatEvent(this, HealingValue);
    }
}
