using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using siteProfissionalFG.Models;
using TesteMaturidadeLinkedin.Models;
using TesteMaturidadeLinkedin.Service.Merge;

namespace TesteMaturidadeLinkedin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MergeDataController : ControllerBase
    {
        private readonly IMergeInterface _mergeInterface;

        public MergeDataController(IMergeInterface mergeInterface)
        {
            _mergeInterface = mergeInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<MergeModel>>>> GetMergedData()
        {
            return Ok(await _mergeInterface.GetMergedData());
        }
    }
}
