using System.Text.Json.Serialization;

namespace ProjetoPortfólio.Api.Models
{
    public class Turma
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [JsonIgnore]

        public List<Aluno>? Alunos { get; set; }

    }
}
