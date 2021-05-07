using SubindoNivel.Common.Services;
using SubindoNivel.Entity.Entities;

namespace SubindoNivel.IService.Services
{
    public interface IProdutoService : IServiceConfiguration
    {
        Produto ObterPorId(int idProduto);
    }
}
