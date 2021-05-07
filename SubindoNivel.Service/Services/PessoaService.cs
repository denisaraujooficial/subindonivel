using SubindoNivel.Entity.Entities;
using SubindoNivel.IService.Services;
using System;

namespace SubindoNivel.Service.Services
{
    public class PessoaService : IPessoaService
    {
        private Pessoa pessoa;

        public PessoaService()
        {
            pessoa = new Pessoa { Nome = "Denis", Idade = new Random().Next() };
        }

        public Pessoa ObterPorId(int idPessoa)
        {
            return pessoa;
        }
    }
}
