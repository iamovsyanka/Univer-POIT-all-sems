namespace Lab5
{
    public abstract class Person
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int CountPublications { get; set; }

        public abstract float WritingExperience(int x, int y);

        public abstract string CreateAlias();

        public abstract override string ToString();
    }
}
