using Hospital.Core.Models.Entities;
using Hospital.Web.Constants;
using Hospital.Web.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Hospital.Core.Abstract.Services;

namespace Hospital.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private IDoctorsService _doctorsService;

        public DoctorsController(IDoctorsService service)
            => _doctorsService = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDoctorsContract>>> Get(int? pageNumber, string? sortingCriteria, CancellationToken token)
        {
            Expression<Func<DoctorEntity, object>> criteria = (DoctorEntity doctor) => (doctor.Id);

            if (sortingCriteria != null)
            {
                criteria = sortingCriteria.ToUpper() switch
                {
                    "FIRSTNAME" => (DoctorEntity doctor) => doctor.FirstName,
                    "FAMILYNAME" => (DoctorEntity doctor) => doctor.FirstName,
                    "PATRONYMIC" => (DoctorEntity doctor) => doctor.FirstName,
                    _ => (DoctorEntity doctor) => (doctor.Id)
                };
            }

            var doctors = await _doctorsService.GetAndSortDoctorsByCriteriaAsync(criteria, token);

            if (pageNumber != null)
            {
                if (pageNumber <= 0)
                    return BadRequest("Parametr pageNumber can't be negative or be equal 0!");

                if (pageNumber > (doctors.Count() / PageConstants.PageSize) + 1)
                    return BadRequest("Parametr pageNumber can't be bigger than quanity of pages!");

                doctors = doctors
                   .Skip(PageConstants.PageSize * (pageNumber.Value - 1))
                   .Take(PageConstants.PageSize);
            }

            var result =
                doctors.ToList()
                .Select(doctor => new GetDoctorsContract(doctor.Id,
                doctor.FirstName, 
                doctor.FamilyName, 
                doctor.Patronymic, 
                doctor.Specialization.Name,
                doctor.Office != null ? doctor.Office.Number : default(int),
                doctor.Area != null ? doctor.Area.Number : default));

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetDoctorContract>> Get(int id, CancellationToken token)
        {
            var doctor = await _doctorsService.GetDoctorByIdAsync(id, token);

            if(doctor == null)
                return NotFound("There is no doctor with this id");

            var result = new GetDoctorContract(doctor.Id, 
                doctor.OfficeId, 
                doctor.SpecializationId, 
                doctor.AreaId, 
                doctor.FirstName,
                doctor.FamilyName,
                doctor.Patronymic);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<DoctorResponse>> Post([FromBody] CreateDoctorContract doctor, CancellationToken token)
        {
            DoctorEntity doctorEntity = new DoctorEntity();

            if (doctor.AreaId.HasValue)
                doctorEntity.AreaId = doctor.AreaId;

            doctorEntity.FirstName = doctor.FirstName;
            doctorEntity.FamilyName = doctor.FamilyName;
            doctorEntity.Patronymic = doctor.Patronymic;
            doctorEntity.OfficeId = doctor.OfficeId;
            doctorEntity.SpecializationId = doctor.SpecializationId;

            var entity = await _doctorsService.CreateDoctorAsync(doctorEntity, token);

            var result = ConvertDoctorEntityToResponse(entity);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EditDoctorContract>> Put(int id, [FromBody] EditDoctorContract doctor, CancellationToken token)
        {
            var doctorEntity = await _doctorsService.GetDoctorByIdAsync(id, token);

            if (doctorEntity == null)
                return NotFound("There is no doctor with this id");
            
            doctorEntity.FirstName = doctor.FirstName ?? doctorEntity.FirstName;
            doctorEntity.FamilyName = doctor.FamilyName ?? doctorEntity.FamilyName;
            doctorEntity.Patronymic = doctor.Patronymic ?? doctorEntity.Patronymic;
            doctorEntity.AreaId = doctor.AreaId ?? doctorEntity.AreaId;
            doctorEntity.OfficeId = doctor.OfficeId ?? doctorEntity.OfficeId;
            doctorEntity.SpecializationId = doctor.SpecializationId ?? doctorEntity.SpecializationId;

            var resultEntity = await _doctorsService.UpdateDoctorAsync(doctorEntity, token);

            var result = ConvertDoctorEntityToResponse(resultEntity);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DoctorResponse>> Delete(int id, CancellationToken token)
        {
            if (await _doctorsService.GetDoctorByIdAsync(id, token) == null)
                return BadRequest("There is no doctor with this id");

            var deletedEntity = await _doctorsService.DeleteDoctorByIdAsync(id, token);
            var result = ConvertDoctorEntityToResponse(deletedEntity);

            return Ok(result);
        }

        private DoctorResponse ConvertDoctorEntityToResponse(DoctorEntity entity)
        {
            return new DoctorResponse(entity.Id,
                entity.FirstName,
                entity.FamilyName,
                entity.Patronymic,
                entity.SpecializationId,
                entity.OfficeId,
                entity.AreaId);
        }
    }
}
