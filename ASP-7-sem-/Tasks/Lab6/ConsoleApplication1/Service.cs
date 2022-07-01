using System;
using System.Linq;

namespace ConsoleApplication1
{
    class Service
    {
        ServiceReference1.lab6Entities db;

        public Service()
        {
            db = new ServiceReference1.lab6Entities(new Uri("http://localhost:61418/WcfDataService2.svc/"));
        }

        public void Print()
        {
            Console.WriteLine("--- Students ---");
            foreach (var student in db.Students)
            {
                Console.WriteLine($"{student.id} - {student.name}");
            }
        }

        public void Add(int id, string name)
        {
            //ServiceReference1.Students student = new ServiceReference1.Students() { name = name };
            db.Execute<ServiceReference1.Students>(new Uri("http://localhost:61418/WcfDataService2.svc/InsertStudent?id=" + id + "&name=\'" + name + "\'"));
            //db.SaveChanges();
        }

        public void Update(int id, string name)
        {
            var student = db.Students.AsEnumerable().First(i => i.id == id);
            student.name = name;
            db.UpdateObject(student);
            db.SaveChanges();
        }
    }
}
