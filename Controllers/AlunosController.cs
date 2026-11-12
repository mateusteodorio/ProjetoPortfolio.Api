using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPortfólio.Api.Data;
using ProjetoPortfólio.Api.Models;

namespace ProjetoPortfólio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlunosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            return await _context.alunos.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostAluno(Aluno aluno)
        {
            _context.alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return Ok("Aluno cadastrado com sucesso!");
        }

        [HttpPut("Id")]
        public async Task<IActionResult> AlterarAluno(int id, Aluno aluno)
        {
            var procuraaluno = await _context.alunos.FindAsync(id);
            if (procuraaluno == null)
            {
                return NotFound();
            }

            procuraaluno.Nome = aluno.Nome;
            procuraaluno.SobreMim = aluno.SobreMim;
            procuraaluno.TecnologiasConhecidas = aluno.TecnologiasConhecidas;
            procuraaluno.HabilidadesCertificados = aluno.HabilidadesCertificados;
            procuraaluno.FerramentasDominadas = aluno.FerramentasDominadas;
            procuraaluno.AreasAtuacao = aluno.AreasAtuacao;




            await _context.SaveChangesAsync();
            return Ok("Informações do aluno foram salvas com sucesso");
        }
        

        [HttpDelete("{id}")]
        public async Task<ActionResult<Aluno>> DeleteAluno(int id)
        {
            var aluno = await _context.alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return Ok("Aluno excluído com sucesso!");
        }
    }
}
