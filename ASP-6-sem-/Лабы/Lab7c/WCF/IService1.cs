using System;
using System.Collections.Generic;
using System.ServiceModel;
using WCF.Models;

namespace WCF
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Contact> GetAll();

        [OperationContract]
        Contact GetById(Guid id);

        [OperationContract]
        Contact Add(string name, string phone);

        [OperationContract]
        Contact Update(Guid id, string name, string phone);

        [OperationContract]
        Guid Delete(Guid id);
    }
}
