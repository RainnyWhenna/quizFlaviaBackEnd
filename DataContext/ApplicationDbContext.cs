using siteProfissionalFG.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TesteMaturidadeLinkedin.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<PessoaModel> Pessoa { get; set; }
        public DbSet<ResultadoModel> Resultado { get; set; }
    }
}
