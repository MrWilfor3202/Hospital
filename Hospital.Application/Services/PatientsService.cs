using Hospital.Core.Abstract.Repositories;
using Hospital.Core.Abstract.Services;
using Hospital.Core.Abstract.UnitOfWork;
using Hospital.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Hospital.Application.Services
{
    public class PatientsService : IPatientsService
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<PatientEntity> _patientsRepository;

        public PatientsService(IUnitOfWork unitOfWork, IGenericRepository<PatientEntity> patientsRepository)
        {
            _patientsRepository = patientsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PatientEntity> CreatePatientAsync(PatientEntity patientEntity, CancellationToken token)
        {
            var result = _patientsRepository.AddEntity(patientEntity);
            await _unitOfWork.CommitAsync(token);

            return result;
        }

        public async Task<PatientEntity> DeletePatientByIdAsync(int id, CancellationToken token)
        {
            var result = await _patientsRepository.DeleteEntityById(id);
            await _unitOfWork.CommitAsync(token);

            return result;
        }

        public async Task<IEnumerable<PatientEntity>> GetAllPatientsAsync(CancellationToken token)
        {
            var patients = await _patientsRepository.ToListAsync(token);

            return patients;
        }

        public async Task<IEnumerable<PatientEntity>> GetAndSortPatientsByCriteriaAsync<V>(Expression<Func<PatientEntity, V>> sortingExpression,
            CancellationToken token)
        {
            var pathients = _patientsRepository.SortEntitiesByCriteria(sortingExpression);

            return await pathients.ToListAsync();
        }

        public async Task<PatientEntity> GetPatientByIdAsync(int id, CancellationToken token)
        {
            var doctor = await _patientsRepository.GetEntityByIdAsync(id, token);

            return doctor;
        }

        public async Task<PatientEntity> UpdatePatientAsync(PatientEntity pathientEntity, CancellationToken token)
        {
            var entity = _patientsRepository.UpdateEntity(pathientEntity);
            await _unitOfWork.CommitAsync(token);

            return entity;
        }
    }
}
