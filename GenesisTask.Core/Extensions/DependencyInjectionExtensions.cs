using GenesisTask.Core.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace GenesisTask.Core.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddCoreComponents(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IVisitRepository, VisitRepository>();
            services.AddScoped<IDiseaseRepository, DiseaseRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();

            return services;
        }
    }
}
