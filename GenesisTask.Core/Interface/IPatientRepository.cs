using GenesisTask.Data.Models;

namespace GenesisTask.Core.Interface
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAll();
        Task<Patient> GetById(int id);
        Task Add(Patient patient);
        Task Update(Patient patient);
        Task Delete(int id);
        Task<IEnumerable<Patient>> GetPatientsByCriteria(int? age, string gender, string disease);
    }
}
