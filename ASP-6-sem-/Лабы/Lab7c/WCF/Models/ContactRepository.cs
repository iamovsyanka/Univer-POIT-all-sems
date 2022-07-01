using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WCF.Models
{
    public class ContactRepository
    {
        private readonly string pathToFile = @"D:\3 курс\ASP-6-sem-\Лабы\Lab7c\WCF\App_Data\PD.json";

        public List<Contact> Contacts { get; set; }

        private List<Contact> ReadFromJson()
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader streamReader = new StreamReader(pathToFile))
            {
                using (JsonTextReader reader = new JsonTextReader(streamReader))
                {
                    return serializer.Deserialize<List<Contact>>(reader).OrderBy(x => x.Name).ToList() ?? new List<Contact>();
                }
            }
        }

        private void WriteToJson()
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter streamWriter = new StreamWriter(pathToFile, false))
            {
                using (JsonTextWriter writer = new JsonTextWriter(streamWriter))
                {
                    serializer.Serialize(writer, Contacts);
                }
            }
        }

        public List<Contact> GetAll() => ReadFromJson();

        public Contact GetById(Guid id)
        {
            Contacts = ReadFromJson();

            return Contacts.FirstOrDefault(x => x.Id == id);
        }

        public Contact Add(string name, string phone)
        {
            Contacts = ReadFromJson();
            Contact newContact = new Contact(name, phone);
            Contacts.Add(newContact);
            WriteToJson();

            return newContact;
        }

        public Contact Update(Guid id, string name, string phone)
        {
            Contacts = ReadFromJson();
            Contact newContact = new Contact(id, name, phone);
            Contact oldContact = Contacts.FirstOrDefault(x => x.Id == newContact.Id);
            if (oldContact != null)
            {
                oldContact.Name = newContact.Name;
                oldContact.Phone = newContact.Phone;
            }
            WriteToJson();

            return newContact;
        }

        public Guid Delete(Guid id)
        {
            Contacts = ReadFromJson();
            Contacts.Remove(Contacts.FirstOrDefault(x => x.Id == id));
            WriteToJson();

            return id;
        }
    }
}
