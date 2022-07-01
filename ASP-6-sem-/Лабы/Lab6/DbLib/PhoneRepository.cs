using System.Collections.Generic;
using System.Linq;

namespace DbLib
{
    public class PhoneRepository : IPhoneDictionary
    {
        private PhoneContext phoneContext = new PhoneContext();

        public void Create(Phone item)
        {
            phoneContext.Phones.Add(item);
            phoneContext.SaveChanges();
        }

        public Phone Get(int id) => phoneContext.Phones.FirstOrDefault(c => c.Id == id);

        public IEnumerable<Phone> GetAll() => phoneContext.Phones.OrderBy(x => x.Name).ToList();

        public void Remove(Phone item)
        {
            phoneContext.Phones.Remove(item);
            phoneContext.SaveChanges();
        }

        public void Update(Phone item)
        {
            Phone contact = Get(item.Id);
            contact.Name = item.Name;
            contact.Number = item.Number;

            phoneContext.SaveChanges();
        }
    }
}
