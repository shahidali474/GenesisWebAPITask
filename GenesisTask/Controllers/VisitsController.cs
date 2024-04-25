using GenesisTask.Core.Dtos;
using GenesisTask.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using GenesisTask.Core.Extensions;

namespace GenesisTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        private readonly IVisitRepository _visitRepository;

        public VisitsController(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitDto>>> GetAllVisits()
        {
            var visits = await _visitRepository.GetAll();
            var visitDtos = visits.Select(visit => visit.MapToDto());
            return Ok(visitDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VisitDto>> GetVisitById(int id)
        {
            var visit = await _visitRepository.GetById(id);
            if (visit == null)
            {
                return NotFound();
            }
            return Ok(visit.MapToDto());
        }

        [HttpPost]
        public async Task<ActionResult<VisitDto>> CreateVisit(VisitDto visitDto)
        {
            var visit = visitDto.MapToModel();
            await _visitRepository.Add(visit);
            return CreatedAtAction(nameof(GetVisitById), new { id = visit.Id }, visit.MapToDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVisit(int id, VisitDto visitDto)
        {
            if (id != visitDto.Id)
            {
                return BadRequest("Visit ID mismatch");
            }

            try
            {
                var existingVisit = await _visitRepository.GetById(id);
                if (existingVisit == null)
                {
                    return NotFound();
                }

                await _visitRepository.Update(existingVisit);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the visit.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVisit(int id)
        {
            var existingVisit = await _visitRepository.GetById(id);
            if (existingVisit == null)
            {
                return NotFound();
            }

            await _visitRepository.Delete(id);

            return NoContent();
        }
    }
}
