using SubindoNivel.Common.Services;
using SubindoNivel.Entity.Entities;

namespace SubindoNivel.IService.Services
{
    public interface IPessoaService : IServiceConfiguration
    {
        Pessoa ObterPorId(int idPessoa);
    }
}
