using Lab3.Models;
using System.Data.Entity;

namespace Lab3.DB
{
    public class Lab3Context : DbContext
    {
        public Lab3Context()
    : base("DBContext")
        { }
        public DbSet<Student> Students { get; set; }
    }
}
