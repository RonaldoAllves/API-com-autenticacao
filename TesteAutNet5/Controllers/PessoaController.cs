using TesteAutNet5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TesteAutNet5.Repositories;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace TesteAutNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {

        //  Inserir uma pessoa na lista
        [HttpPost]
        [Route("Inserir")]
        [Authorize(Roles = "Gerente,Funcionario")]
        public async Task<ActionResult<Pessoa>> Post(
            [FromBody] PessoaRecebida model)
        {

            if (ModelState.IsValid)
            {
                var m = PessoaRepository.inserir(model);
                return m;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        //  Obter a lista de pessoas salvas.
        [HttpGet]
        [Authorize(Roles = "Gerente,Funcionario")]
        public List<Pessoa> Get()
        {
            return PessoaRepository.All();
        }


        //  Obter os dados de pessoa pelo Id
        [HttpGet]
        [Route("ID")]
        [Authorize(Roles = "Gerente,Funcionario")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Pessoa> Get([FromQuery] int id)
        {
            var a = PessoaRepository.Id(id);
            if (a != null) return a;
            else return NotFound();
        }


        //  Obter lista de pessoas de uma determinada UF
        [HttpGet]
        [Route("UF")]
        [Authorize(Roles = "Gerente,Funcionario")]
        public List<Pessoa> Get([FromQuery] string uf)
        {
            return PessoaRepository.UF(uf);
        }


        //  Deletar uma pessoa da lista
        [HttpDelete]
        [Route("DeleteById")]
        [Authorize(Roles = "Gerente")]
        public ActionResult<Pessoa> Delete(int id)
        {
            var p = PessoaRepository.Deletar(id);
            if (p != null)
            {
                return p;
            }
            return NotFound();
        }


        //  Atualizar uma pessoa pelo id da pessoa passada.
        [HttpPost]
        [Route("Atualizar")]
        [Authorize(Roles = "Gerente,Funcionario")]
        public async Task<ActionResult<Pessoa>> Post(
            [FromBody] Pessoa model)
        {

            if (ModelState.IsValid)
            {
                var p = PessoaRepository.Atualizar(model);
                if (p != null) return p;
                else return NotFound();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
