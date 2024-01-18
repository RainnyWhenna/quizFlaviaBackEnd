using Microsoft.EntityFrameworkCore;
using siteProfissionalFG.Models;
using TesteMaturidadeLinkedin.DataContext;

namespace TesteMaturidadeLinkedin.Service.PessoaService
{
    public class PessoaService : IPessoaInterface
    {
        private readonly ApplicationDbContext _context;
        public PessoaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<PessoaModel>>> GetPessoas()
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();
            try {
                serviceResponse.Dados = _context.Pessoa.ToList();

                if (serviceResponse.Dados.Count == 0) {
                    serviceResponse.Mensagem = "Nenhum dado encontrado";
                }
            }
            catch {
                throw;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<PessoaModel>> GetPessoaById(int idPessoa)
        {
            ServiceResponse<PessoaModel> serviceResponse = new ServiceResponse<PessoaModel>();

            try {
                PessoaModel pessoa = _context.Pessoa.FirstOrDefault(x => x.IdPessoa == idPessoa);

                if (pessoa == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não encontrado";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = pessoa;
            }
            catch {
                throw;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PessoaModel>>> CreatePessoa(PessoaModel novaPessoa)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();

            try {
                if(novaPessoa == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informe os dados.";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novaPessoa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Pessoa.ToList();
            }
            catch {
                throw;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PessoaModel>>> DeletePessoa(int idPessoa)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();

            try {
                List<PessoaModel> pessoa = await _context.Pessoa.Where(x => x.IdPessoa == idPessoa).ToListAsync();

                if (pessoa == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Resultado não encontrado.";
                    serviceResponse.Sucesso = false;
                } else {
                    _context.Pessoa.RemoveRange(pessoa);
                    await _context.SaveChangesAsync();
                }

                serviceResponse.Dados = _context.Pessoa.ToList();
            }
            catch {
                throw;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PessoaModel>>> DeleteAll()
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();

            try {
                List<PessoaModel> todasPessoas = await _context.Pessoa.ToListAsync();

                if (todasPessoas.Count == 0) {
                    serviceResponse.Mensagem = "Nenhum resultado encontrado.";
                    serviceResponse.Sucesso = false;
                } else {
                    _context.Pessoa.RemoveRange(todasPessoas);
                    await _context.SaveChangesAsync();

                    serviceResponse.Dados = await _context.Pessoa.ToListAsync();
                }
            }
            catch {
                throw;
            }

            return serviceResponse;
        }
    }
}
