using Hospital.Application.Services;
using Hospital.Core.Abstract.Services;
using Hospital.Core.Models.Entities;
using Hospital.Web.Constants;
using Hospital.Web.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;


namespace Hospital.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private IPatientsService _patientsService;

        public PatientsController(IPatientsService service)
            => _patientsService = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreatePatientContract>>> Get(int? pageNumber, string? sortingCriteria, CancellationToken token)
        {
            Expression<Func<PatientEntity, object>> criteria = (PatientEntity patient) => (patient.Id);

            if (sortingCriteria != null)
            {
                criteria = sortingCriteria.ToUpper() switch
                {
                    "FIRSTNAME" => (PatientEntity patient) => patient.FirstName,
                    "FAMILYNAME" => (PatientEntity patient) => patient.FirstName,
                    "PATRONYMIC" => (PatientEntity patient) => patient.FirstName,
                    "BIRTHDATE" => (PatientEntity patient) => patient.BirthDate,
                    "SEX" => (PatientEntity patient) => patient.Sex,
                    _ => (PatientEntity patient) => (patient.Id)
                };
            }

            var patients = await _patientsService.GetAndSortPatientsByCriteriaAsync(criteria, token);

            if (pageNumber != null)
            {
                if (pageNumber <= 0)
                    return BadRequest("Parametr pageNumber can't be negative or be equal 0!");

                if (pageNumber > (patients.Count() / PageConstants.PageSize) + 1)
                    return BadRequest("Parametr pageNumber can't be bigger than quanity of pages!");

                patients = patients
                   .Skip(PageConstants.PageSize * (pageNumber.Value - 1))
                   .Take(PageConstants.PageSize);
            }

            var result =
                patients
                .Select(patient => new GetPatientsContarct(
                    patient.Id,
                    patient.FirstName,
                    patient.FamilyName,
                    patient.Patronymic,
                    patient.Address,
                    patient.Sex,
                    patient.BirthDate,
                    patient.Area.Number
                ));

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPatientContract>> Get(int id, CancellationToken token)
        {
            var patient = await _patientsService.GetPatientByIdAsync(id, token);

            if (patient == null)
                return NotFound("There is no patient with this id");

            var result = new GetPatientContract(patient.Id,
                patient.AreaId,
                patient.FirstName,
                patient.FamilyName,
                patient.Patronymic,
                patient.Address,
                patient.Sex,
                patient.BirthDate);

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<PatientResponse>> Post([FromBody] CreatePatientContract patient, CancellationToken token)
        {
            PatientEntity patientEntity = new PatientEntity();

            patientEntity.FirstName = patient.FirstName;
            patientEntity.FamilyName = patient.FamilyName;
            patientEntity.Patronymic = patient.Patronymic;
            patientEntity.Sex = patient.Sex;
            patientEntity.BirthDate = patient.BirthDate;
            patientEntity.Address = patient.Address;
            patientEntity.AreaId = patient.AreaId;

            var entity = await _patientsService.CreatePatientAsync(patientEntity, token);
            var result = ConvertPatientEntityToResponse(entity);

            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PatientResponse>> Put(int id, [FromBody] EditPatientContract patient, CancellationToken token)
        {
            var patientEntity = await _patientsService.GetPatientByIdAsync(id, token);

            if (patientEntity == null)
                return NotFound("There is no patient with this id");

            patientEntity.FirstName = patient.FirstName ?? patientEntity.FirstName;
            patientEntity.FamilyName = patient.FamilyName ?? patientEntity.FamilyName;
            patientEntity.Patronymic = patient.Patronymic ?? patientEntity.Patronymic;
            patientEntity.Sex = patient.Sex ?? patientEntity.Sex;
            patientEntity.BirthDate = patient.BirthDate ?? patientEntity.BirthDate;
            patientEntity.Address = patient.Address ?? patientEntity.Address;
            patientEntity.AreaId = patient.AreaId ?? patientEntity.AreaId;

            var resultEntity = await _patientsService.UpdatePatientAsync(patientEntity, token);
            var result = ConvertPatientEntityToResponse(resultEntity);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PatientResponse>> Delete(int id, CancellationToken token)
        {
            if(await _patientsService.GetPatientByIdAsync(id, token) == null)
                return NotFound("There is no patient with this id");

            var deletedEntity = await _patientsService.DeletePatientByIdAsync(id, token);
            var result = ConvertPatientEntityToResponse(deletedEntity);

            return Ok(result);
        }

        private PatientResponse ConvertPatientEntityToResponse(PatientEntity entity)
        {
            return new PatientResponse(entity.Id,
                entity.FirstName,
                entity.FamilyName,
                entity.Patronymic,
                entity.Address,
                entity.Sex,
                entity.BirthDate,
                entity.AreaId);
        }
    }
}
