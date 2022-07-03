using Lab14.Context;
using Lab14.Models;
using Lab14.Repository.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Lab14.Repository
{
    public class UserConcertRepository : IUserConcertRepository
    {
        private ConcertContext concertContext;
        public UserConcertRepository(ConcertContext concertContext)
        {
            this.concertContext = concertContext;
        }

        public IQueryable<UserConcert> Get() => concertContext.UserConcerts;

        public async Task AddAsync(UserConcert concert)
        {
            if (concert == null)
            {
                throw new ArgumentException();
            }

            await concertContext.UserConcerts.AddAsync(concert);
            await concertContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(int concertId)
        {
            var concertToRemove = await concertContext.UserConcerts.FindAsync(concertId);

            if (concertToRemove != null)
            {
                concertContext.UserConcerts.Remove(concertToRemove);
            }
            await concertContext.SaveChangesAsync();
        }
        public void Remove(int concertId)
        {
            var concertToRemove = concertContext.UserConcerts.Find(concertId);

            if (concertToRemove != null)
            {
                concertContext.UserConcerts.Remove(concertToRemove);
            }
            concertContext.SaveChanges();
        }
        public async Task UpdateAsync(int concertId, UserConcert newUserConcert)
        {
            var concertToChange = await concertContext.UserConcerts.FindAsync(concertId);

            await concertContext.SaveChangesAsync();
        }
    }
}
