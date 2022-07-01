using Asmx.Models;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace Asmx
{
    /// <summary>
    /// Сводное описание для WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        private ContactRepository repository = new ContactRepository();

        [WebMethod(EnableSession = true, Description = "Get all contact")]
        public List<Contact> GetDict()
        {
            return repository.GetAll();
        }

        [WebMethod(EnableSession = true, Description = "Get contact")]
        public Contact GetRecord(Guid id)
        {
            return repository.GetById(id);
        }

        [WebMethod(EnableSession = true, Description = "Add contact")]
        public Contact AddDict(string name, string phone)
        {
            return repository.Add(name, phone);
        }

        [WebMethod(EnableSession = true, Description = "Update contact")]
        public Contact UpdDict(Guid id, string name, string phone)
        {
            return repository.Update(id, name, phone);
        }

        [WebMethod(EnableSession = true, Description = "Delete contact")]
        public Guid DelDict(Guid id)
        {
            return repository.Delete(id);
        }
    }
}
