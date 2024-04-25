using GenesisTask.Data.Models;

namespace GenesisTask.Core.Interface
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAll();
        Task<Doctor> GetById(int id);
        Task Add(Doctor doctor);
        Task Update(Doctor doctor);
        Task Delete(int id);
    }
}
