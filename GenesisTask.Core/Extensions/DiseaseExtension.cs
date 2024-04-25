using GenesisTask.Core.Dtos;
using GenesisTask.Data.Models;

namespace GenesisTask.Core.Extensions
{
    public static class DiseaseExtension
    {
        public static DiseaseDto MapToDto(this Disease disease)
        {
            return new DiseaseDto
            {
                Id = disease.Id,
                Name = disease.Name
            };
        }
        public static Disease MapToModel(this DiseaseDto diseaseDto)
        {
            return new Disease
            {
                Id = diseaseDto.Id,
                Name = diseaseDto.Name
            };
        }
    }
}
