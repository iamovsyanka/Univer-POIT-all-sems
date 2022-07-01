using Lab7a.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;

namespace Lab7a.Controllers
{
    public class TSController : ApiController
    {
        private const string file = @"D:\3 курс\ASP-6-sem-\Лабы\Lab7a\Lab7a\App_Data\PD.json";
        static public List<Contact> Contacts { get; set; }

        [HttpPost]
        public IHttpActionResult Add([FromBody]Contact item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = Guid.NewGuid();
            Contacts.Add(new Contact { Id = id, Name = item.Name, Phone = item.Phone });

            string json = JsonConvert.SerializeObject(Contacts);
            File.WriteAllText(file, json);

            return Ok();
        }

        public Contact Get(Guid id) => Contacts.Find(c => c.Id == id);

        [HttpGet]
        public IEnumerable<Contact> GetAll()
        {
            string jsonString = File.ReadAllText(file);
            Contacts = JsonConvert.DeserializeObject<List<Contact>>(jsonString).ToList();

            return Contacts.OrderBy(c => c.Name).ToList();
        }

        [HttpDelete]
        public void Remove([FromBody] Guid id)
        {
            Contacts.Remove(Get(id));

            string json = JsonConvert.SerializeObject(Contacts);
            File.WriteAllText(file, json);
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody]Contact item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Contact newContact = Get(item.Id);
            newContact.Name = item.Name;
            newContact.Phone = item.Phone;

            string json = JsonConvert.SerializeObject(Contacts);
            File.WriteAllText(file, json);

            return Ok();
        }
    }
}
