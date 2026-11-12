using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPortfólio.Api.Data;
using ProjetoPortfólio.Api.Models;

namespace ProjetoPortfólio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjetosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projeto>>> GetProjetos()
        {
            return await _context.projetos.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostProjeto(Projeto projeto)
        {
            _context.projetos.Add(projeto);
            await _context.SaveChangesAsync();
            return Ok("Projeto cadastrado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarProjeto(int id, Projeto projeto)
        {
            var procuraprojeto = await _context.projetos.FindAsync(id);
            if (procuraprojeto == null)
            {
                return NotFound();
            }

            procuraprojeto.Titulo = projeto.Titulo;
            procuraprojeto.Descricao = projeto.Descricao;
            procuraprojeto.LinkDeAcesso = projeto.LinkDeAcesso;
            procuraprojeto.TecnologiasUtilizadas = projeto.TecnologiasUtilizadas;
            procuraprojeto.ImagemVideo = projeto.ImagemVideo;
            procuraprojeto.AlunoId = projeto.AlunoId;







            await _context.SaveChangesAsync();

            return Ok("Projeto atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirProjeto(int id)
        {
            var projeto = await _context.projetos.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }

            _context.projetos.Remove(projeto);
            await _context.SaveChangesAsync();

            return Ok("Projeto excluído com sucesso!");
        }
    }
}
