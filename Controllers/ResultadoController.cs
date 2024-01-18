using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using siteProfissionalFG.Models;
using TesteMaturidadeLinkedin.Service.PessoaService;
using TesteMaturidadeLinkedin.Service.ResultadoService;

namespace TesteMaturidadeLinkedin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadoController : ControllerBase
    {
        private readonly IResultadoInterface _resultadoInterface;

        public ResultadoController(IResultadoInterface resultadoInterface)
        {
            _resultadoInterface = resultadoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ResultadoModel>>>> GetResultados()
        {
            return Ok(await _resultadoInterface.GetResultados());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ResultadoModel>>>> CreateResultado(ResultadoModel novoResultado)
        {
            return Ok(await _resultadoInterface.CreateResultado(novoResultado));
        }

        [HttpGet("idPessoa")]
        public async Task<ActionResult<ServiceResponse<ResultadoModel>>> GetResultadosByPessoa(int idPessoa)
        {
            return Ok(await _resultadoInterface.GetResultadosByPessoa(idPessoa));
        }

        [HttpDelete("idPessoa")]
        public async Task<ActionResult<ServiceResponse<ResultadoModel>>> DeleteResultadoPessoa(int idPessoa)
        {
            return Ok(await _resultadoInterface.DeleteResultadoPessoa(idPessoa));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<ResultadoModel>>> DeleteAll()
        {
            return Ok(await _resultadoInterface.DeleteAll());
        }
    }
}
