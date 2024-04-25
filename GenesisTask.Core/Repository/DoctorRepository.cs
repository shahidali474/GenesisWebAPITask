using GenesisTask.Core.Interface;
using GenesisTask.Data;
using GenesisTask.Data.Models;
using Microsoft.EntityFrameworkCore;

public class DoctorRepository : IDoctorRepository
{
    private readonly GenesisTaskContext _context;

    public DoctorRepository(GenesisTaskContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Doctor>> GetAll()
    {
        return await _context.Doctors.ToListAsync();
    }

    public async Task<Doctor> GetById(int id)
    {
        return await _context.Doctors.FindAsync(id);
    }

    public async Task Add(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Doctor doctor)
    {
        _context.Entry(doctor).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor != null)
        {
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }
    }
}
