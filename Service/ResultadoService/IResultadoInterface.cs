using siteProfissionalFG.Models;

namespace TesteMaturidadeLinkedin.Service.ResultadoService
{
    public interface IResultadoInterface
    {
        Task<ServiceResponse<List<ResultadoModel>>> GetResultados();
        Task<ServiceResponse<ResultadoModel>> GetResultadosByPessoa(int idPessoa);
        Task<ServiceResponse<List<ResultadoModel>>> CreateResultado(ResultadoModel novoResultado);
        Task<ServiceResponse<List<ResultadoModel>>> DeleteResultadoPessoa(int idPessoa);
        Task<ServiceResponse<List<ResultadoModel>>> DeleteAll();
    }
}
