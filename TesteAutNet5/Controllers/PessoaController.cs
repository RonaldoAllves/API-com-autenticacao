using CriacaoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace CriacaoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();

        [HttpGet]
        [Authorize(Roles = "Gerente,Funcionario")]
        public List<Pessoa> Get()
        {
            return pessoas;
        }

        [HttpGet]
        [Route("ID")]
        [Authorize(Roles = "Gerente,Funcionario")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Pessoa> Get([FromQuery] int id)
        {
            var searchID = pessoas.Where(item => item.Id == id).FirstOrDefault();
            //Pessoa p = pessoas.First(x => x.Id.Equals(id));
            if (searchID != null)
            {
                return searchID;
            }

            return NotFound();
        }

        [HttpGet]
        [Route("UF")]
        [Authorize(Roles = "Gerente,Funcionario")]
        public List<Pessoa> Get([FromQuery] string uf)
        {
            List<Pessoa> pessoasUF = new List<Pessoa>();

            foreach (Pessoa p in pessoas)
            {
                if (p.Uf.Equals(uf))
                {
                    pessoasUF.Add(p);
                }
            }

            return pessoasUF;
        }

        [HttpPost]
        [Route("Inserir")]
        [Authorize(Roles = "Gerente,Funcionario")]
        public async Task<ActionResult<Pessoa>> Post(
            [FromBody] Pessoa model)
        {

            if (ModelState.IsValid)
            {
                pessoas.Add(model);
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("DeleteById")]
        [Authorize(Roles = "Gerente")]
        public void Delete(int id)
        {
            pessoas.RemoveAt(pessoas.IndexOf(pessoas.First(x => x.Id.Equals(id))));
        }

        [HttpPut]
        [Route("Atualizar")]
        [Authorize(Roles = "Gerente,Funcionario")]
        public async Task<ActionResult<Pessoa>> Put(
            [FromBody] Pessoa model)
        {

            if (ModelState.IsValid)
            {
                int index = pessoas.IndexOf(pessoas.First(x => x.Id.Equals(model.Id)));
                pessoas[index] = model;
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
