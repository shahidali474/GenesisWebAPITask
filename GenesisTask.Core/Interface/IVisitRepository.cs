using GenesisTask.Data.Models;

namespace GenesisTask.Core.Interface
{
    public interface IVisitRepository
    {
        Task<IEnumerable<Visit>> GetAll();
        Task<Visit> GetById(int id);
        Task Add(Visit visit);
        Task Update(Visit visit);
        Task Delete(int id);
    }
}
