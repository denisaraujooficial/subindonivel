using Microsoft.AspNetCore.Mvc;
using SubindoNivel.Entity.Entities;
using SubindoNivel.IService.Services;

namespace SubindoNivel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet("{id}")]
        public Pessoa Get(int id)
        {
            var pessoa = _pessoaService.ObterPorId(id);

            return pessoa;
        }

    }
}
