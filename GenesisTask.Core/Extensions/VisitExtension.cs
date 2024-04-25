using GenesisTask.Core.Dtos;
using GenesisTask.Data.Models;

namespace GenesisTask.Core.Extensions
{
    public static class VisitExtension
    {
        public static VisitDto MapToDto(this Visit visit)
        {
            return new VisitDto
            {
                Id = visit.Id,
                VisitDate = visit.VisitDate,
                Disease = visit.Disease,
                PatientId = visit.PatientId,
                DoctorId = visit.DoctorId
            };
        }
        public static Visit MapToModel(this VisitDto visitDto)
        {
            return new Visit
            {
                Id = visitDto.Id,
                VisitDate = visitDto.VisitDate,
                Disease = visitDto.Disease,
                PatientId = visitDto.PatientId,
                DoctorId = visitDto.DoctorId
            };
        }
    }


}
