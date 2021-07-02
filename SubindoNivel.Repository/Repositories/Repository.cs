using SubindoNivel.IRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubindoNivel.Repository.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        public Task Add(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> FindByID(long id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(long id)
        {
            throw new NotImplementedException();
        }

        public Task Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
