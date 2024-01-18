using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace siteProfissionalFG.Models
{
    public class ResultadoModel
    {
        [Key]
        public int IdResultado { get; set; }

        public DateTime RespondidoEm { get; set; } = DateTime.Now.ToLocalTime();
        public string pergunta { get; set; }
        public string resposta { get; set; }

        [ForeignKey("IdPessoa")]
        public int IdPessoa { get; set; }
    }
}
