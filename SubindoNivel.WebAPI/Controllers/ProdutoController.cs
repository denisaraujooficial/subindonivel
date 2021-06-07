using Microsoft.AspNetCore.Mvc;
using SubindoNivel.Entity.Entities;
using SubindoNivel.IService.Services;

namespace SubindoNivel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("{id}")]
        public Produto Get(int id)
        {
            var produto = _produtoService.ObterPorId(id);

            return produto;
        }
    }
}
