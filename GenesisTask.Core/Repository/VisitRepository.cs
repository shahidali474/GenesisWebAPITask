using GenesisTask.Core.Interface;
using GenesisTask.Data;
using GenesisTask.Data.Models;
using Microsoft.EntityFrameworkCore;

public class VisitRepository : IVisitRepository
{
    private readonly GenesisTaskContext _context;

    public VisitRepository(GenesisTaskContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Visit>> GetAll()
    {
        return await _context.Visits.ToListAsync();
    }

    public async Task<Visit> GetById(int id)
    {
        return await _context.Visits.FindAsync(id);
    }

    public async Task Add(Visit visit)
    {
        _context.Visits.Add(visit);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Visit visit)
    {
        _context.Entry(visit).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var visit = await _context.Visits.FindAsync(id);
        if (visit != null)
        {
            _context.Visits.Remove(visit);
            await _context.SaveChangesAsync();
        }
    }
}
