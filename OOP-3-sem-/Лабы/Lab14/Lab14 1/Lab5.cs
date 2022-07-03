using System;

namespace Lab14
{
    [Serializable]
    public abstract class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CountPublications { get; set; }
        public abstract float WritingExperience(int x, int y);
        public abstract string CreateAlias();
        public abstract override string ToString();
    }

    [Serializable]
    public class Author : Person
    {
        public Author() { }
        public Author(string _name, string _surname, int _countPublications)
        {
            Name = _name;
            Surname = _surname;
            CountPublications = _countPublications;
        }

        public override float WritingExperience(int year, int yearOfWriting) => (float)yearOfWriting / year;

        public override string CreateAlias() => Name.ToUpper() + Surname.Substring(0, 2);

        public override string ToString() => $"Тип объекта: {GetType()}, фамилия и имя автора - {Surname} {Name}, количество книг - {CountPublications}";
    }
}
