using System;
using System.Collections.Generic;
using System.Linq;
using Lab4.Models;
using Lab4.Context;

namespace Lab4.Repository
{
    public class ContactRepository : IRepository<Contact>
    {
        private ContactContext contactContext = new ContactContext();

        public void Create(Contact item)
        {
            contactContext.Contacts.Add(item);
            contactContext.SaveChanges();
        }

        public Contact Get(int id) => contactContext.Contacts.FirstOrDefault(c => c.Id == id);

        public IEnumerable<Contact> GetAll() => contactContext.Contacts.OrderBy(x => x.Name).ToList();

        public void Remove(Contact item)
        {
            contactContext.Contacts.Remove(item);
            contactContext.SaveChanges();
        }

        public void Update(Contact item)
        {
            Contact contact = Get(item.Id);
            contact.Name = item.Name;
            contact.Phone = item.Phone;

            contactContext.SaveChanges();
        }
    }
}