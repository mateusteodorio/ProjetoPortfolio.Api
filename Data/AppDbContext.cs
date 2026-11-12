using Microsoft.EntityFrameworkCore;
using ProjetoPortfólio.Api.Models;

namespace ProjetoPortfólio.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions
           options) : base(options) { }

        public DbSet<LoginSistema> loginSistemas { get; set; }
        public DbSet<Turma> turmas { get; set; }
        public DbSet<Aluno> alunos { get; set; }
        public DbSet<Projeto> projetos { get; set; }



    }
}
