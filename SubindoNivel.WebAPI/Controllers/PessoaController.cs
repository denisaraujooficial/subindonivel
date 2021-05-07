using Microsoft.AspNetCore.Mvc;
using SubindoNivel.Entity.Entities;
using SubindoNivel.IService.Services;
using SubindoNivel.Common.Extensions;
using System;

namespace SubindoNivel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;
        private readonly IProdutoService _produtoService;

        public PessoaController(
            IPessoaService pessoaService,
            IProdutoService produtoService)
        {
            _pessoaService = pessoaService;
            _produtoService = produtoService;
        }

        [HttpGet("{id}")]
        public Pessoa Get(int id)
        {
            var pessoa = _pessoaService.ObterPorId(id);
            var produto = _produtoService.ObterPorId(id);

            return pessoa;
        }

    }
}
