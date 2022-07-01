using System.Data.Entity;

namespace DbLib
{
    public class PhoneContext : DbContext
    {
        public PhoneContext() : base("DefaultConnection")
        { }

        public DbSet<Phone> Phones { get; set; }
    }
}
