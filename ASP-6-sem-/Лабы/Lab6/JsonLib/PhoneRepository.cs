using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JsonLib
{
    public class PhoneRepository : IPhoneDictionary
    {
        private const string file = @"D:\3 курс\ASP-6-sem-\Лабы\Lab6\JsonLib\PD.json";
        static public List<Phone> Phones { get; set; }

        public void Create(Phone item)
        {
            if (item != null)
            {
                if (Get(item.Id) == null)
                {
                    var id = Phones.Count + 1;
                    Phones.Add(new Phone { Id = id, Name = item.Name, Number = item.Number });

                    Save();
                }
            }
        }

        public Phone Get(int id) => Phones.Find(c => c.Id == id);

        public IEnumerable<Phone> GetAll()
        {
            string jsonString = File.ReadAllText(file);
            Phones = JsonConvert.DeserializeObject<List<Phone>>(jsonString).ToList();

            return Phones.OrderBy(c => c.Name).ToList();
        }

        public void Remove(Phone item)
        {
            if (item != null)
            {
                Phones.Remove(Get(item.Id));

                Save();
            }
        }

        public void Update(Phone item)
        {
            if (item != null)
            {
                Phone newContact = Get(item.Id);
                newContact.Name = item.Name;
                newContact.Number = item.Number;

                Save();
            }
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(Phones);
            File.WriteAllText(file, json);
        }
    }
}
