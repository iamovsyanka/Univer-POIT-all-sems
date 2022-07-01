using System.Collections.Generic;

namespace JsonLib
{
    public interface IPhoneDictionary
    {
        IEnumerable<Phone> GetAll();
        Phone Get(int id);
        void Create(Phone item);
        void Remove(Phone item);
        void Update(Phone item);
        void Save();
    }
}
