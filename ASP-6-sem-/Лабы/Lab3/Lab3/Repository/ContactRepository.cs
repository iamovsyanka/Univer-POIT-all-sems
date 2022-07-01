using Lab3.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Lab3.Repository
{
    public class ContactRepository : IRepository<Contact>
    {
        private const string file = @"D:\3 курс\ASP-6-sem-\Лабы\Lab3\Lab3\App_Data\PD.json";
        static public List<Contact> Contacts { get; set; }

        public void Create(Contact item)
        {
            if (item != null)
            {
                if (Get(item.Id) == null)
                {
                    var id = Contacts.Count + 1;
                    Contacts.Add(new Contact{ Id = id, Name = item.Name, Phone = item.Phone });

                    Save();
                }
            }
        }

        public Contact Get(int id) => Contacts.Find(c => c.Id == id);

        public IEnumerable<Contact> GetAll()
        {
            string jsonString = File.ReadAllText(file);
            Contacts = JsonConvert.DeserializeObject<List<Contact>>(jsonString).ToList();

            return Contacts.OrderBy(c => c.Name).ToList();
        }

        public void Remove(Contact item)
        {
            if(item != null)
            {
                Contacts.Remove(Get(item.Id));

                Save();
            }
        }

        public void Update(Contact item)
        {
            if (item != null) 
            {
                Contact newContact = Get(item.Id);
                newContact.Name = item.Name;
                newContact.Phone = item.Phone;

                Save();
            }
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(Contacts);
            File.WriteAllText(file, json);
        }
    }
}