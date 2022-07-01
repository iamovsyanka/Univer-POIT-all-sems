using Lab4.Models;
using System.Data.Entity;

namespace Lab4.Context
{
    public class ContactContext : DbContext
    {
        public ContactContext() : base("DefaultConnection")
        { }

        public DbSet<Contact> Contacts { get; set; }
    }
}