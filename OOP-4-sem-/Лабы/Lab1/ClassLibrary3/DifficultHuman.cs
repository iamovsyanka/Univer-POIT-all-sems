namespace Lab1.Builder
{
    public class DifficultHuman
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public string Education { get; set; }

        public int FamilySize { get; set; }

        public override string ToString() => $"Name - {Name}\t Age - {Age} years old \t FamilySize - {FamilySize} members\t Education - {Education}\t";
    }
}
