using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using siteProfissionalFG.Models;
using TesteMaturidadeLinkedin.Service.PessoaService;

namespace TesteMaturidadeLinkedin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaInterface _pessoaInterface;

        public PessoaController(IPessoaInterface pessoaInterface)
        {
            _pessoaInterface = pessoaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PessoaModel>>>> GetPessoas()
        {
            return Ok(await _pessoaInterface.GetPessoas());
        }

        [HttpGet("{idPessoa}")]
        public async Task<ActionResult<ServiceResponse<PessoaModel>>> GetPessoaById(int idPessoa)
        {
            return Ok(await _pessoaInterface.GetPessoaById(idPessoa));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<PessoaModel>>>> CreatePessoa(PessoaModel novaPessoa)
        {
            return Ok(await _pessoaInterface.CreatePessoa(novaPessoa));
        }

        [HttpDelete("idPessoa")]
        public async Task<ActionResult<ServiceResponse<PessoaModel>>> DeletePessoa(int idPessoa)
        {
            return Ok(await _pessoaInterface.DeletePessoa(idPessoa));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<PessoaModel>>> DeleteAll()
        {
            return Ok(await _pessoaInterface.DeleteAll());
        }
    }
}
