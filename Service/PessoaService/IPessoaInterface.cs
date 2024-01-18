using siteProfissionalFG.Models;

namespace TesteMaturidadeLinkedin.Service.PessoaService
{
    public interface IPessoaInterface
    {
        Task<ServiceResponse<List<PessoaModel>>> GetPessoas();
        Task<ServiceResponse<PessoaModel>> GetPessoaById(int idPessoa);
        Task<ServiceResponse<List<PessoaModel>>> CreatePessoa(PessoaModel novaPessoa);
        Task<ServiceResponse<List<PessoaModel>>> DeletePessoa(int idPessoa);
        Task<ServiceResponse<List<PessoaModel>>> DeleteAll();
    }
}
