using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPortfólio.Api.Data;
using ProjetoPortfólio.Api.Models;

namespace ProjetoPortfólio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TurmasController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]

        public async Task<ActionResult<IEnumerable<Turma>>> GetTurmas()
        {   

           return await _context.turmas.ToListAsync();

        }

        [HttpPost]
        public async Task<IActionResult> CriarTurma(Turma turma)
        {
            _context.turmas.Add(turma);
            await _context.SaveChangesAsync();

            return Ok("Turma Criada com sucesso");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTurma(int id, Turma turma)
        {
            var procuraturma = await _context.turmas.FindAsync(id);
            if (procuraturma == null)
            {
                return NotFound();
            }

            procuraturma.Nome = turma.Nome;




            await _context.SaveChangesAsync();
            return Ok("Informações da turma foram salvas com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarTurma(int id)
        {
            var turma = await _context.turmas.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }

            _context.Remove(turma);

            await _context.SaveChangesAsync();

            return Ok("Turma deletada com sucesso");
        }
    }
}
