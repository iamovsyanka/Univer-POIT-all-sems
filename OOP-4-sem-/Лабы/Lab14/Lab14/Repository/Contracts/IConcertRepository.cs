using Lab14.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab14.Repository.Contracts
{
    interface IConcertRepository : IRepository<Concert>
    {
        List<Concert> GetList();
        public Concert GetByGroup(string group);
        public Task RemoveTicket(string concertGroup);
    }
}
