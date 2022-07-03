using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public double AverageScore { get; set; }
        public Student() { }
        public Student(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public double GetAverageScore()
        {
            Random random = new Random();
            AverageScore = random.Next(1,9)+random.NextDouble();
            return AverageScore;
        }
        public override string ToString()
        {
            return $"Имя и фамилия студента: {Name} {Surname}, средний балл: {GetAverageScore()}";
        }
    }
}
