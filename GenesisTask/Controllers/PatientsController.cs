using GenesisTask.Core.Dtos;
using GenesisTask.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using GenesisTask.Core.Extensions;

namespace GenesisTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientsController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetAllPatients()
        {
            var patients = await _patientRepository.GetAll();
            var patientDtos = patients.Select(patient => patient.MapToDto());
            return Ok(patientDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetPatientById(int id)
        {
            var patient = await _patientRepository.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient.MapToDto());
        }

        [HttpPost]
        public async Task<ActionResult<PatientDto>> CreatePatient(PatientDto patientDto)
        {
            var patient = patientDto.MapToModel();
            await _patientRepository.Add(patient);
            return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id }, patient.MapToDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, PatientDto patientDto)
        {
            if (id != patientDto.Id)
            {
                return BadRequest("Patient ID mismatch");
            }

            try
            {
                var existingPatient = await _patientRepository.GetById(id);
                if (existingPatient == null)
                {
                    return NotFound();
                }

                existingPatient.Name = patientDto.Name;
                existingPatient.Age = patientDto.Age;
                existingPatient.Gender = patientDto.Gender;
                await _patientRepository.Update(existingPatient);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the patient.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            var existingPatient = await _patientRepository.GetById(id);
            if (existingPatient == null)
            {
                return NotFound();
            }

            await _patientRepository.Delete(id);

            return NoContent();
        }

        [HttpGet("criteria")]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatientsByCriteria(int? age, string gender, string disease)
        {
            var patients = await _patientRepository.GetPatientsByCriteria(age, gender, disease);
            var patientDtos = patients.Select(patient => patient.MapToDto());
            return Ok(patientDtos);
        }
    }

}
