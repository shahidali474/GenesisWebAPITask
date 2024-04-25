using GenesisTask.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GenesisTask.Data
{
    public class GenesisTaskContext : DbContext
    {
        public GenesisTaskContext(DbContextOptions<GenesisTaskContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }
}