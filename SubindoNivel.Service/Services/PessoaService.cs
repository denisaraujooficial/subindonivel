using SubindoNivel.Entity.Entities;
using SubindoNivel.IService.Services;

namespace SubindoNivel.Service.Services
{
    public class PessoaService : IPessoaService
    {
        public Pessoa ObterPorId(int idPessoa)
        {
            return new Pessoa { Nome = "Denis", Idade = 32 };
        }
    }
}
