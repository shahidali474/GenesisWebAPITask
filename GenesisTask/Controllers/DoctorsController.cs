using GenesisTask.Core.Dtos;
using GenesisTask.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using GenesisTask.Core.Extensions;

namespace GenesisTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorsController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetAllDoctors()
        {
            var doctors = await _doctorRepository.GetAll();
            var doctorDtos = doctors.Select(doctor => doctor.MapToDto());
            return Ok(doctorDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDto>> GetDoctorById(int id)
        {
            var doctor = await _doctorRepository.GetById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor.MapToDto());
        }

        [HttpPost]
        public async Task<ActionResult<DoctorDto>> CreateDoctor(DoctorDto doctorDto)
        {
            var doctor = doctorDto.MapToModel();
            await _doctorRepository.Add(doctor);
            return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id }, doctor.MapToDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, DoctorDto doctorDto)
        {
            if (id != doctorDto.Id)
            {
                return BadRequest("Doctor ID mismatch");
            }

            try
            {
                var existingDoctor = await _doctorRepository.GetById(id);
                if (existingDoctor == null)
                {
                    return NotFound();
                }

                existingDoctor.Name = doctorDto.Name;
                await _doctorRepository.Update(existingDoctor);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the doctor.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            var existingDoctor = await _doctorRepository.GetById(id);
            if (existingDoctor == null)
            {
                return NotFound();
            }

            await _doctorRepository.Delete(id);

            return NoContent();
        }
    }
}
