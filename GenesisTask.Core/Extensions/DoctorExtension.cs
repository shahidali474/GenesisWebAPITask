using GenesisTask.Core.Dtos;
using GenesisTask.Data.Models;

namespace GenesisTask.Core.Extensions
{
    public static class DoctorExtension
    {
        public static DoctorDto MapToDto(this Doctor doctor)
        {
            return new DoctorDto
            {
                Id = doctor.Id,
                Name = doctor.Name
            };
        }
        public static Doctor MapToModel(this DoctorDto doctorDto)
        {
            return new Doctor
            {
                Id = doctorDto.Id,
                Name = doctorDto.Name
            };
        }
    }

}
