using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPortfólio.Api.Data;
using ProjetoPortfólio.Api.Models;

namespace ProjetoPortfólio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginSistemasController : ControllerBase
    {

        private readonly AppDbContext _context;

        public LoginSistemasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]

        public  IActionResult Login(LoginSistema login)
        {
            var user = _context.loginSistemas.FirstOrDefault(u => login.Nome == u.Nome && u.Senha == login.Senha && u.Id > 0 );

            if (user == null)
            {

                return Unauthorized("Alguma informação (Usuario ou senha) está Incorreta!");

            }


            return Ok(new { Nome = user.Nome });
        }

        [HttpPost]

        public async Task<IActionResult> CadastrarUsuario(LoginSistema usuario)
        {
            _context.loginSistemas.AddAsync(usuario);
            _context.SaveChangesAsync();
            return Ok($"Usuario '{usuario.Nome}' Cadastrado com sucesso");
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<LoginSistema>>> GetClientes()
        {
            return await _context.loginSistemas.ToListAsync();
        }


    }
}
