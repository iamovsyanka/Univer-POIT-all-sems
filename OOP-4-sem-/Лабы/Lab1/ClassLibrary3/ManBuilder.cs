namespace Lab1.Builder
{
    public class ManBuilder : DifficultHumanBuilder
    {
        public override void SetAge() => Human.Age = 25;

        public override void SetEducation() => Human.Education = "Ph degree";

        public override void SetFamilySize() => Human.FamilySize = 2;

        public override void SetName() => Human.Name = "Alexander";
    }
}
