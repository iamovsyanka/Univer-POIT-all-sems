using Lab14.Context;
using Lab14.Models;
using Lab14.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab14.Repository
{
    public class ConcertRepository : IConcertRepository
    {
        private ConcertContext concertContext;
        public ConcertRepository(ConcertContext concertContext)
        {
            this.concertContext = concertContext;
        }

        public IQueryable<Concert> Get() => concertContext.Concerts;

        public async Task AddAsync(Concert concert)
        {
            if (concert == null)
            {
                throw new ArgumentException();
            }

            await concertContext.Concerts.AddAsync(concert);
            await concertContext.SaveChangesAsync();
        }

        public void Remove(int concertId)
        {
            var concertToRemove = concertContext.Concerts.FirstOrDefault(g => g.ConcertId == concertId);
            if (concertToRemove != null)
            {
                concertContext.Remove(concertToRemove);
                concertContext.SaveChanges();
            }
        }

        public async Task RemoveTicket(string concertGroup)
        {
            var concertToRemove = concertContext.Concerts.FirstOrDefault(g => g.Group == concertGroup);

            concertToRemove.Count++;
            await concertContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(int concertId)
        {
            var concertToRemove = concertContext.Concerts.FirstOrDefault(g => g.ConcertId == concertId);
            if (concertToRemove.Count > 0)
            {
                concertToRemove.Count--;
                await concertContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(int concertId, Concert newConcert)
        {
            var concertToChange = concertContext.Concerts.FirstOrDefault(g => g.ConcertId == concertId);

            concertToChange.Count = newConcert.Count;
            concertToChange.Zone = newConcert.Zone;

            await concertContext.SaveChangesAsync();
        }

        public List<Concert> GetList() => Get().ToList();

        public Concert GetByGroup(string group) => concertContext.Concerts.FirstOrDefault(g => g.Group == group);
    }
}
