using SubindoNivel.Entity.Entities;
using SubindoNivel.IService.Services;
using System.Linq.Expressions;

namespace SubindoNivel.Service.Services
{
    public class ProdutoService : IProdutoService
    {
        public Produto ObterPorId(int idProduto)
        {
            return new Produto { Qtd = 10, Descricao = "Carro" };
        }
    }
}
