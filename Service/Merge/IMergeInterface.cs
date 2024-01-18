using siteProfissionalFG.Models;
using TesteMaturidadeLinkedin.Models;

namespace TesteMaturidadeLinkedin.Service.Merge
{
    public interface IMergeInterface
    {
        Task<ServiceResponse<List<MergeModel>>> GetMergedData();
    }
}
