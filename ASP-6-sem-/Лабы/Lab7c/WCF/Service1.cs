using System;
using System.Collections.Generic;
using WCF.Models;

namespace WCF
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        private ContactRepository contactRepository = new ContactRepository();

        public Contact Add(string name, string phone)
        {
            return contactRepository.Add(name, phone);
        }

        public Guid Delete(Guid id)
        {
            return contactRepository.Delete(id);
        }

        public List<Contact> GetAll()
        {
            return contactRepository.GetAll();
        }

        public Contact GetById(Guid id)
        {
            return contactRepository.GetById(id);
        }

        public Contact Update(Guid id, string name, string phone)
        {
            return contactRepository.Update(id, name, phone);
        }
    }
}
