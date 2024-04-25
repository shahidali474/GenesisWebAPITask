using GenesisTask.Core.Dtos;
using GenesisTask.Data.Models;

namespace GenesisTask.Core.Extensions
{
    public static class PatientExtension
    {
        public static PatientDto MapToDto(this Patient patient)
        {
            return new PatientDto
            {
                Id = patient.Id,
                Name = patient.Name,
                Age = patient.Age,
                Gender = patient.Gender,
                PhoneNumber = patient.PhoneNumber,
                Address = patient.Address
            };
        }
        public static Patient MapToModel(this PatientDto patientDto)
        {
            return new Patient
            {
                Id = patientDto.Id,
                Name = patientDto.Name,
                Age = patientDto.Age,
                Gender = patientDto.Gender,
                PhoneNumber = patientDto.PhoneNumber,
                Address = patientDto.Address
            };
        }
    }

}
