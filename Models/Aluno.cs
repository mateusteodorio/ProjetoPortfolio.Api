using System.Text.Json.Serialization;

namespace ProjetoPortfólio.Api.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string SobreMim { get; set; }

        public string TecnologiasConhecidas { get; set; }

        public string HabilidadesCertificados { get; set; }

        public string FerramentasDominadas { get; set; }

        public string AreasAtuacao { get; set; }

        public int TurmaId { get; set; }

        public Turma? Turma { get; set; }

        [JsonIgnore]

        public List<Projeto>? Projetos { get; set; }






    }
}
