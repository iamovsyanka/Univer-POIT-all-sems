using Lab14.Context;
using Lab14.Models;
using Lab14.Repository.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Lab14.Repository
{
    public class UserRepository : IUserRepository
    {
        private ConcertContext concertContext;
        public UserRepository(ConcertContext concertContext)
        {
            this.concertContext = concertContext;
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
        public IQueryable<User> Get() => concertContext.Users;

        public async Task AddAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentException();
            }

            await concertContext.Users.AddAsync(user);
            await concertContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(int userId)
        {
            var userToRemove = await concertContext.Users.FindAsync(userId);

            if(userToRemove != null)
            {
                concertContext.Users.Remove(userToRemove);
            }
            await concertContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int userId, User newUser)
        {
            var userToChange = await concertContext.Users.FindAsync(userId);

            userToChange.Password = newUser.Password;
            userToChange.UserName = newUser.UserName;

            await concertContext.SaveChangesAsync();
        }

        public User GetItem(string userName) => concertContext.Users.FirstOrDefault(user => user.UserName == userName);
    }
}
