using GenesisTask.Core.Interface;
using GenesisTask.Data;
using GenesisTask.Data.Models;
using Microsoft.EntityFrameworkCore;

public class DiseaseRepository : IDiseaseRepository
{
    private readonly GenesisTaskContext _context;

    public DiseaseRepository(GenesisTaskContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Disease>> GetAll()
    {
        return await _context.Diseases.ToListAsync();
    }

    public async Task<Disease> GetById(int id)
    {
        return await _context.Diseases.FindAsync(id);
    }

    public async Task Add(Disease disease)
    {
        _context.Diseases.Add(disease);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Disease disease)
    {
        _context.Entry(disease).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var disease = await _context.Diseases.FindAsync(id);
        if (disease != null)
        {
            _context.Diseases.Remove(disease);
            await _context.SaveChangesAsync();
        }
    }
}
