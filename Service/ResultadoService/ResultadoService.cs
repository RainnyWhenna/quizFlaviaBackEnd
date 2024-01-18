using Microsoft.EntityFrameworkCore;
using siteProfissionalFG.Models;
using TesteMaturidadeLinkedin.DataContext;

namespace TesteMaturidadeLinkedin.Service.ResultadoService
{
    public class ResultadoService : IResultadoInterface
    {
        private readonly ApplicationDbContext _context;
        public ResultadoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ResultadoModel>>> GetResultados()
        {
            ServiceResponse<List<ResultadoModel>> serviceResponse = new ServiceResponse<List<ResultadoModel>>();
            try {
                serviceResponse.Dados = _context.Resultado.ToList();

                if (serviceResponse.Dados.Count == 0) {
                    serviceResponse.Mensagem = "Nenhum dado encontrado";
                }
            }
            catch {
                throw;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ResultadoModel>>> CreateResultado(ResultadoModel novoResultado)
        {
            ServiceResponse<List<ResultadoModel>> serviceResponse = new ServiceResponse<List<ResultadoModel>>();

            try {
                _context.Add(novoResultado);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Resultado.ToList();
            }
            catch {
                throw;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<ResultadoModel>> GetResultadosByPessoa(int idPessoa)
        {
            ServiceResponse<ResultadoModel> serviceResponse = new ServiceResponse<ResultadoModel>();

            try {
                ResultadoModel resultado = _context.Resultado.FirstOrDefault(x => x.IdPessoa == idPessoa);

                if (resultado == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não encontrado";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = resultado;
            }
            catch {
                throw;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ResultadoModel>>> DeleteResultadoPessoa(int idPessoa)
        {
            ServiceResponse<List<ResultadoModel>> serviceResponse = new ServiceResponse<List<ResultadoModel>>();

            try {
                List<ResultadoModel> resultadoPessoa = await _context.Resultado.Where(x => x.IdPessoa == idPessoa).ToListAsync();

                if (resultadoPessoa == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Resultado não encontrado.";
                    serviceResponse.Sucesso = false;
                } else {
                    _context.Resultado.RemoveRange(resultadoPessoa);
                    await _context.SaveChangesAsync();
                }

                serviceResponse.Dados = _context.Resultado.ToList();
            }
            catch {
                throw;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ResultadoModel>>> DeleteAll()
        {
            ServiceResponse<List<ResultadoModel>> serviceResponse = new ServiceResponse<List<ResultadoModel>>();

            try {
                List<ResultadoModel> todosResultados = await _context.Resultado.ToListAsync();

                if (todosResultados.Count == 0) {
                    serviceResponse.Mensagem = "Nenhum resultado encontrado.";
                    serviceResponse.Sucesso = false;
                } else {
                    _context.Resultado.RemoveRange(todosResultados);
                    await _context.SaveChangesAsync();

                    serviceResponse.Dados = await _context.Resultado.ToListAsync();
                }
            }
            catch {
                throw;
            }

            return serviceResponse;
        }
    }
}
