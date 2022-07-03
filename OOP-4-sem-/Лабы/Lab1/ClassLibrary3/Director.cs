namespace Lab1.Builder
{
    public class Director
    {
        public DifficultHuman Create(DifficultHumanBuilder difficultHumanBuilder)
        {
            difficultHumanBuilder.CreateHuman();
            difficultHumanBuilder.SetAge();
            difficultHumanBuilder.SetName();
            difficultHumanBuilder.SetFamilySize();
            difficultHumanBuilder.SetEducation();
            return difficultHumanBuilder.Human;
        }
    }
}
