using GenesisTask.Core.Interface;
using GenesisTask.Data;
using GenesisTask.Data.Models;
using Microsoft.EntityFrameworkCore;

public class PatientRepository : IPatientRepository
{
    private readonly GenesisTaskContext _context;

    public PatientRepository(GenesisTaskContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Patient>> GetAll()
    {
        return await _context.Patients.ToListAsync();
    }

    public async Task<Patient> GetById(int id)
    {
        return await _context.Patients.FindAsync(id);
    }

    public async Task Add(Patient patient)
    {
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Patient patient)
    {
        _context.Entry(patient).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient != null)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Patient>> GetPatientsByCriteria(int? age, string gender, string disease)
    {
        IQueryable<Patient> query = _context.Patients;

        if (age.HasValue)
        {
            query = query.Where(p => p.Age == age);
        }

        if (!string.IsNullOrEmpty(gender))
        {
            query = query.Where(p => p.Gender == gender);
        }

        // Add more criteria as needed (e.g., disease)

        return await query.ToListAsync();
    }
}
