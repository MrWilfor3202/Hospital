using Hospital.Core.Abstract.Repositories;
using Hospital.Core.Abstract.UnitOfWork;
using Hospital.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Hospital.Core.Abstract.Services;
namespace Hospital.Application.Services
{
    public class DoctorsService : IDoctorsService
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<DoctorEntity> _doctorsRepository;

        public DoctorsService(IUnitOfWork unitOfWork, IGenericRepository<DoctorEntity> doctorsRepository) 
        {
            _doctorsRepository = doctorsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DoctorEntity> CreateDoctorAsync(DoctorEntity doctorEntity, CancellationToken token)
        {
            var result = _doctorsRepository.AddEntity(doctorEntity);
            await _unitOfWork.CommitAsync(token);

            return result;
        }

        public async Task<DoctorEntity> DeleteDoctorByIdAsync(int id, CancellationToken token)
        {
            var result = await _doctorsRepository.DeleteEntityById(id);
            await _unitOfWork.CommitAsync(token);

            return result;
        }

        public async Task<IEnumerable<DoctorEntity>> GetAllDoctorsAsync(CancellationToken token)
        {
            var doctors = await _doctorsRepository.ToListAsync(token);

            return doctors;
        }

        public async Task<IEnumerable<DoctorEntity>> GetAndSortDoctorsByCriteriaAsync<V>(Expression<Func<DoctorEntity, V>> sortingExpression,
            CancellationToken token)
        {
            var doctors = _doctorsRepository.SortEntitiesByCriteria(sortingExpression);

            return await doctors.ToListAsync();
        }

        public async Task<DoctorEntity> GetDoctorByIdAsync(int id, CancellationToken token)
        {
            var doctor = await _doctorsRepository.GetEntityByIdAsync(id, token);

            return doctor;
        }

        public async Task<DoctorEntity> UpdateDoctorAsync(DoctorEntity doctorEntity, CancellationToken token)
        {
            var entity = _doctorsRepository.UpdateEntity(doctorEntity);
            await _unitOfWork.CommitAsync(token);

            return entity;
        }
    }
}
