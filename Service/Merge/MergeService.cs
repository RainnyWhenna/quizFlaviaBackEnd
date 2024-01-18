using Microsoft.EntityFrameworkCore;
using siteProfissionalFG.Models;
using TesteMaturidadeLinkedin.DataContext;
using TesteMaturidadeLinkedin.Models;

namespace TesteMaturidadeLinkedin.Service.Merge
{
    public class MergeService : IMergeInterface
    {

        private readonly ApplicationDbContext _context;
        public MergeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<MergeModel>>> GetMergedData()
        {
            ServiceResponse<List<MergeModel>> serviceResponse = new ServiceResponse<List<MergeModel>>();

            try {
                List<PessoaModel> pessoas = await _context.Pessoa.ToListAsync();
                List<ResultadoModel> resultados = await _context.Resultado.ToListAsync();

                // Combinação de dados usando IdPessoa como chave comum
                var mergedData = from pessoa in pessoas
                                 join resultado in resultados on pessoa.IdPessoa equals resultado.IdPessoa
                                 select new MergeModel {
                                     IdPessoa = pessoa.IdPessoa,
                                     NomeCompleto = pessoa.NomeCompleto,
                                     Email = pessoa.Email,
                                     Whatsapp = pessoa.Whatsapp,
                                     Linkedin = pessoa.Linkedin,
                                     RespondidoEm = resultado.RespondidoEm.ToString("yyyy-MM-dd"), // Formate a data conforme necessário
                                     Pergunta = resultado.pergunta,
                                     Resposta = resultado.resposta
                                 };

                serviceResponse.Dados = mergedData.ToList();

                if (serviceResponse.Dados.Count == 0) {
                    serviceResponse.Mensagem = "Nenhum dado encontrado após a combinação";
                }
            }
            catch (Exception ex) {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
            }

            return serviceResponse;
        }

    }
}
