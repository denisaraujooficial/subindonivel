using SubindoNivel.Common.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SubindoNivel.IRepository.Repositories
{
    public interface IRepository<T> : IRepositoryConfiguration
    {
        Task Add(T item);
        Task Remove(long id);
        Task Update(T item);
        Task<T> FindByID(long id);
        IEnumerable<T> FindAll();
    }
}
