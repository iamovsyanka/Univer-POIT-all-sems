using System.Linq;
using System.Threading.Tasks;

namespace Lab14.Repository.Contracts
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        Task AddAsync(T item);
        Task UpdateAsync(int itemId, T newItem);
        void Remove(int itemId);
    }
}
