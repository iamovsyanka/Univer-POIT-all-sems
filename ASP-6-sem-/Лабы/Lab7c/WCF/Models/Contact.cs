using System;

namespace WCF.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public Contact() { }

        public Contact(string name, string phone)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Phone = phone;
        }

        public Contact(Guid id, string name, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
        }

        public override string ToString() => Name + " " + Phone;
    }
}
