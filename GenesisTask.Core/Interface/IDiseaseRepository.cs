using GenesisTask.Data.Models;

namespace GenesisTask.Core.Interface
{
    public interface IDiseaseRepository
    {
        Task<IEnumerable<Disease>> GetAll();
        Task<Disease> GetById(int id);
        Task Add(Disease disease);
        Task Update(Disease disease);
        Task Delete(int id);
    }
}
