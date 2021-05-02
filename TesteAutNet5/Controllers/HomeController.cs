using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteAutNet5.Models;
using TesteAutNet5.Repositories;
using TesteAutNet5.Services;

namespace TesteAutNet5.Controllers
{

    [Route("v1/account")]
    public class HomeController : ControllerBase
    {

        /*###########################################################*/
        /*###########################################################*/

        [HttpPost]
        [Route("criarToken")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> Authenticate([FromQuery] String username, String password, String role)
        {

            //Insere novo usuario
            var user = UserRepository.Set(username, password, role);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user
            };
        }

        [HttpGet]
        [Route("listarUsuarios")]
        [Authorize(Roles = "Gerente")]

        public async Task<ActionResult<dynamic>> ListarUsuarios()
        {
            // Retorna os dados
            return UserRepository.All();
        }
    }

}
