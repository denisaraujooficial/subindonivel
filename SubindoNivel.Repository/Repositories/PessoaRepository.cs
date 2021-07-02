using NHibernate;
using SubindoNivel.Entity.Entities;
using SubindoNivel.IRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubindoNivel.Repository.Repositories
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository()
        {
            
        }

    }
}
