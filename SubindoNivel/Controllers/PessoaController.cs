using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubindoNivel.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubindoNivel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        //private readonly PessoaService

        public PessoaController()
        {

        }

        [HttpGet("{id}")]
        public Pessoa Get(int id)
        {
            return null;
        }
    }
}
