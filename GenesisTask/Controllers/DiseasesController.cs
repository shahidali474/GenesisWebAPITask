using GenesisTask.Core.Dtos;
using GenesisTask.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using GenesisTask.Core.Extensions;

namespace GenesisTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        private readonly IDiseaseRepository _diseaseRepository;

        public DiseasesController(IDiseaseRepository diseaseRepository)
        {
            _diseaseRepository = diseaseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiseaseDto>>> GetAllDiseases()
        {
            var diseases = await _diseaseRepository.GetAll();
            var diseaseDtos = diseases.Select(disease => disease.MapToDto());
            return Ok(diseaseDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiseaseDto>> GetDiseaseById(int id)
        {
            var disease = await _diseaseRepository.GetById(id);
            if (disease == null)
            {
                return NotFound();
            }
            return Ok(disease.MapToDto());
        }

        [HttpPost]
        public async Task<ActionResult<DiseaseDto>> CreateDisease(DiseaseDto diseaseDto)
        {
            var disease = diseaseDto.MapToModel();
            await _diseaseRepository.Add(disease);
            return CreatedAtAction(nameof(GetDiseaseById), new { id = disease.Id }, disease.MapToDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDisease(int id, DiseaseDto diseaseDto)
        {
            if (id != diseaseDto.Id)
            {
                return BadRequest("Disease ID mismatch");
            }

            try
            {
                var existingDisease = await _diseaseRepository.GetById(id);
                if (existingDisease == null)
                {
                    return NotFound();
                }

                await _diseaseRepository.Update(existingDisease);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the disease.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDisease(int id)
        {
            var existingDisease = await _diseaseRepository.GetById(id);
            if (existingDisease == null)
            {
                return NotFound();
            }

            await _diseaseRepository.Delete(id);

            return NoContent();
        }
    }
}
