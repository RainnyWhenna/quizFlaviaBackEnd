using System.ComponentModel.DataAnnotations;

namespace siteProfissionalFG.Models
{
    public class PessoaModel
    {
        [Key]
        public int IdPessoa { get; set; }

        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public string Linkedin { get; set; }
    }
}
