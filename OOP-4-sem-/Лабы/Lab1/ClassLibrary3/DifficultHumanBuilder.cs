namespace Lab1.Builder
{
    abstract public class DifficultHumanBuilder
    {
         public DifficultHuman Human { get; private set; }

         public void CreateHuman()
         {
             Human = new DifficultHuman();
         }

         public abstract void SetAge();

         public abstract void SetName();

         public abstract void SetEducation();

         public abstract void SetFamilySize();
    }
}
