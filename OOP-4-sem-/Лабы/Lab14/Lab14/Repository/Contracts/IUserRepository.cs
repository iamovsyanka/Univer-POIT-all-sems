using Lab14.Models;

namespace Lab14.Repository.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetItem(string userName);
    }
}
